using generatePDF.Controllers;
using System.Diagnostics;
using System.Net;
using System.Text;
using PdfSharp.Pdf.IO;
using PdfDocument = PdfSharp.Pdf.PdfDocument;
using PdfPage = PdfSharp.Pdf.PdfPage;
using System.Text;
using System.Threading.Tasks;
using generatePDF.HTML;
using static generatePDF.Controllers.Person;
using System.Runtime.Intrinsics.X86;
using PdfSharp.Drawing;
using NReco;

namespace generatePDF.Functions
{
    public class HelperPersonScanReport
    {
        internal static string GeneratePdfPersonScanResult(PersonScanRequest personScanRequest, PersonScanResponse personScanResponse)
        {

            // initi variables for the 

            string htmlFirstHeader = HTML.FirstPage.HtmlHeader;
            string htmlHeader = HTML.SecondPage.HtmlHeader;
            string htmlFooter = HTML.SecondPage.HtmlFooter;
            string htmlFirstPage = HTML.FirstPage.HtmlContent;
            string htmlContent = HTML.SecondPage.HtmlContent;
            string htmlPersons = HTML.SecondPage.HtmlPerson;


            string nonPersonImage = "http://clara-compliance.com/wp-content/uploads/2024/05/user.png";
            string firstName = personScanRequest.firstName;
            string lastName = personScanRequest.lastName;
            string colorStatu = "white";
            string lawngreen = "#32CD32";
            string red = "red";
            string img = null;
            double averageRate = 0;
            double sumRate = 0;
            int personCount = personScanResponse.persons.Count;
            string scanId = personScanResponse.scanId;
            string date = personScanResponse.date.ToString();
            string personStatu = null;

            if (personScanResponse.persons.Count == 0 || personScanResponse.persons[0].flag == 0)
            {
                personStatu = "Negative";
                colorStatu = lawngreen;
            }
            else
            {
                personStatu = "Suspicious";
                colorStatu = red;
            }

            // caculate the average of the rates
            foreach (var peron in personScanResponse.persons)
            {
                sumRate = sumRate + peron.matchRate;
            }
            averageRate = sumRate / (double)personCount;

            //find a image from the xml
            foreach (var person in personScanResponse.persons)
            {
                if (person.images.Count > 0)
                {
                    img = person.images[0].ToString();
                    break;
                }
            }

            //the replace the date and scan id form the xml
            htmlFirstHeader = htmlFirstHeader.Replace("[@HEADER.SCAN.VALUE]", scanId)
                .Replace("[@HEADER.DATE.VALUE]", date);
            htmlHeader = htmlHeader.Replace("[@HEADER.SCAN.VALUE]", scanId);
            htmlHeader = htmlHeader.Replace("[@HEADER.DATE.VALUE]", date);
            string personTemplate = "                    <tr class=\"matching-font\">\r\n                        <th class=\"matching-font\" scope=\"row\">[NUMBER]</th>\r\n                        <td>[@PERSON.NAME]</td>\r\n                        <td>[@PERSON.TYPE]</td>\r\n                        <td>[@PERSON.OCCUPATIONS]</td>\r\n                        <td>[@PERSON.DESCRIPTION]</td>\r\n                    </tr>";
            StringBuilder personsHtml = new StringBuilder();
            int i = 1;
            foreach (var person in personScanResponse.persons)
            {

                string occupations = null;
                occupations = FindOccupations(person.occupations);


                //building html columes as much as the persons 
                string personHtml = personTemplate
                    .Replace("[@PERSON.NAME]", person.name ?? "N/A")
                    .Replace("[@PERSON.TYPE]", person.referenceType)
                    .Replace("[@PERSON.OCCUPATIONS]", occupations ?? "N/A")
                    .Replace("[@PERSON.DESCRIPTION]", person.title ?? "N/A")
                    .Replace("[NUMBER]", i.ToString());
                i++;
                personsHtml.Append(personHtml);

            }

            // if there is no image, then set the nonperson image
            if (img == null)
            {
                img = nonPersonImage;
            }

            // replace the values in the html
            htmlFirstPage = htmlFirstPage.Replace("[@PERSONS.DATA]", personsHtml.ToString())
                .Replace("[@first-name]", firstName)
                .Replace("[@last-name]", lastName)
                .Replace("[image.url]", img)
                .Replace("[color-statu]", colorStatu)
                .Replace("[match-rate]", averageRate.ToString("F2") + "%" ?? "N/A")
                .Replace("[@HEADER.SCAN.VALUE]", personScanResponse.scanId?.ToString())
                .Replace("[@HEADER.DATE.VALUE]", personScanResponse.date.ToString())
                .Replace("[pep-statu]", personStatu);

            var firstPDF = GeneratePdft(htmlFirstPage, htmlFirstHeader, htmlFooter);

            var htmlPersonContent = "";
            int count = 1;
            // to create a pdf file for every person
            foreach (var person in personScanResponse.persons)
            {
                htmlPersonContent += GeneratePersonHtml(person, personScanResponse.date, htmlContent);
                if (count <= (personCount - 1))
                {
                    htmlPersonContent += "<div style=\"page-break-before:always\">&nbsp;</div> ";
                }
                count++;
            }


            List<byte[]> listToMerge = new List<byte[]>();
            listToMerge.Add(firstPDF);

            if (htmlPersonContent != "")
            {
                htmlPersons = htmlPersons.Replace("[pleaceholder-content]", htmlPersonContent);
                var secondPDF = GeneratePdft(htmlPersons, htmlHeader, htmlFooter);

                listToMerge.Add(secondPDF);
            }
            var finalPDF = MergePdfFiles(listToMerge);

            string bas64Str = Convert.ToBase64String(finalPDF);
            return (bas64Str);
        }

        internal static string FindImage(List<string> images)
        {
            string nonPersonImage = "http://clara-compliance.com/wp-content/uploads/2024/05/user.png";
            bool exists = false;
            string image = null;


            if (images.Count > 0)
            {
                image = images[0].ToString();

                if (Uri.TryCreate(image, UriKind.Absolute, out Uri uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps))
                {
                    HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(image);
                    request.Method = "HEAD";
                    try
                    {
                        request.GetResponse();
                        exists = true;
                    }
                    catch
                    {
                        exists = false;
                    }
                }
            }
            if (image == null || exists == false)
            {
                image = nonPersonImage;
            }
            return image;
        }

        internal static byte[] GeneratePdft(string htmlTemplate, string header, string footer)
        {
            var ToPdf = new NReco.PdfGenerator.HtmlToPdfConverter
            {
                Size = NReco.PdfGenerator.PageSize.A4,
                Margins = new NReco.PdfGenerator.PageMargins { Top = 50, Bottom = 50, Left = 10, Right = 10 },
                Orientation = NReco.PdfGenerator.PageOrientation.Portrait,
                PageHeaderHtml = header,
                PageFooterHtml = footer,
                PageHeight = 297,
                PageWidth = 210

            };

            return ToPdf.GeneratePdf(htmlTemplate);
        }

        public static string FindOccupations(List<string> occupations)
        {
            string return_value = null;
            if (occupations.Count > 0)
            {
                foreach (var occupation in occupations)
                {
                    if (occupation.Length > 0)
                    {
                        return_value += return_value + " ";
                    }
                }
            }
            return return_value;
        }

        public static (string Twitter, string Instagram, string Facebook) ExtractContactInfo(Person.Contacts contact)
        {
            string twitter = null;
            string instagram = null;
            string facebook = null;

            foreach (var contactInfo in contact.ContactList)
            {
                if (contactInfo != null)
                {
                    if (contactInfo.Type.Equals("Twitter username"))
                    {
                        twitter = contactInfo.Value.ToString();
                    }
                    if (contactInfo.Type.Equals("Instagram username"))
                    {
                        instagram = contactInfo.Value.ToString();
                    }
                    if (contactInfo.Type.Equals("Facebook username"))
                    {
                        facebook = contactInfo.Value.ToString();
                    }
                }
            }

            return (twitter, instagram, facebook);
        }

        public static byte[] MergePdfFiles(List<byte[]> pdfs)
        {
            using (PdfDocument outputDocument = new PdfDocument())
            {
                foreach (var file in pdfs)
                {

                    using (PdfDocument inputDocument = PdfReader.Open(new MemoryStream(file), PdfDocumentOpenMode.Import))
                    {
                        int count = inputDocument.PageCount;
                        for (int idx = 0; idx < count; idx++)
                        {
                            PdfPage page = inputDocument.Pages[idx];
                            outputDocument.AddPage(page);
                        }
                    }
                }
                var mergeFile = new MemoryStream();
                outputDocument.Save(mergeFile);
                return mergeFile.ToArray();
            }
        }

        public static string GeneratePersonHtml(Person person, DateTime date, string contentHTMl)
        {
            string SecondPageTemplatHtml = contentHTMl;
            var birthdays = person.datesOfBirth.Dates;
            string birthday = null;
            string occupations = null;
            string twitter = null;
            string instagram = null;
            string facebook = null;
            string placesOfBirth = null;
            string childern = null;
            string roles = null;
            string country = null;
            string otherNames = null;
            string summary = null;
            string residentialPlaces = null;
            string matchRate = null;
            string imgInLoop = null;
            string mother = null;
            string father = null;
            string citizenship = null;
            string firstNameInLoop = null;
            string lastNameInLoop = null;

            firstNameInLoop = person.firstName;
            lastNameInLoop = person.lastName;
            citizenship = person.citizenship.ToString();
            mother = person.mother.ToString();
            father = person.father.ToString();
            matchRate = person.matchRate.ToString();
            summary = person.summary.ToString();

            if (birthdays != null)
            {
                birthday = birthdays.Date.ToString();
            }

            if (string.IsNullOrEmpty(firstNameInLoop))
            {
                firstNameInLoop = "N/A";
            }
            if (string.IsNullOrEmpty(lastNameInLoop))
            {
                lastNameInLoop = "N/A";
            }

            if (string.IsNullOrEmpty(summary))
            {
                summary = "N/A";
            }

            foreach (var place in person.places.PlaceList)
            {
                if (place != null && place.Type.Equals("residence") && place.Country != null)
                {
                    residentialPlaces += " " + place.Country.ToString();
                }
            }

            foreach (var address in person.addresses.Address)
            {
                if (address.Country != null)
                {
                    country = address.Country;
                    break;
                }
            }

            imgInLoop = FindImage(person.images);
            SecondPageTemplatHtml = SecondPageTemplatHtml.Replace("[image.url]", imgInLoop);

            // to get the occupations from a person
            occupations = FindOccupations(person.occupations);

            // to get the children from a person
            foreach (var child in person.children)
            {
                childern += child + ",";
            }
            foreach (var role in person.roles.RoleList)
            {
                if (role != null && role.Title != null)
                {
                    roles += role.Title;
                }
            }

            // to get the contact info from a person
            (twitter, instagram, facebook) = ExtractContactInfo(person.contact);

            // get the place of birth
            if (person.placesOfBirth.Places != null)
            {
                if (person.placesOfBirth.Places.Country != null)
                {
                    placesOfBirth = person.placesOfBirth.Places.Country.ToString();
                }
            }

            // get the other names
            if (person.otherNames != null && person.otherNames.Name != null)
            {
                if (person.otherNames.Name.Name != null)
                {
                    otherNames = person.otherNames.Name.Name;
                }
            }

            SecondPageTemplatHtml = SecondPageTemplatHtml
                .Replace("[@HEADER.SCAN.VALUE]", person.uid ?? "N/A")
                .Replace("[@HEADER.DATE. VALUE]", date.ToString() ?? "N/A")
                .Replace("[@first-name]", firstNameInLoop)
                .Replace("[@last-name]", lastNameInLoop)
                .Replace("[@date-of-birth]", birthday ?? "N/A")
                .Replace("[@father]", father ?? "N/A")
                .Replace("[@citizenship]", citizenship)
                .Replace("[@mother]", mother ?? "N?A")
                .Replace("[@children]", childern ?? "N/A")
                .Replace("[@occupations]", occupations ?? "N/A")
                .Replace("[@type]", person.referenceType ?? "N/A")
                .Replace("[@email]", "ff" ?? "N/A")
                .Replace("[@summary]", summary ?? "N/A")
                .Replace("[@place-of-birth]", placesOfBirth ?? "N/A")
                .Replace("[@roles]", roles)
                .Replace("[@adresse]", country ?? "N/A")
                .Replace("[@other names]", otherNames)
                .Replace("[@twitter-account-name]", twitter ?? "N?A")
                .Replace("[@instagram-account-name]", instagram ?? "N?A")
                .Replace("[@facebook-account-name]", facebook ?? "N?A")
                .Replace("[@residentials]", residentialPlaces ?? "N/A")
                .Replace("[Match-rate]", matchRate ?? "N/A");

            return SecondPageTemplatHtml;
        }
    }
}
