using System;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace generatePDF.Controllers
{
    public class PersonScanResponse
    {
        public DateTime date { get; set; }
        public string scanId { get; set; }
        public int numberOfMatches { get; set; } // bronze - totalhits
        public List<Person> persons { get; set; } // bronze - found record

        public PersonScanResponse()
        {
            this.persons = new List<Person>();
        }
    }

    public class Person
    {
        public string uid { get; set; } //personmore.uniqueid //bronze - source id
        public string updateAt { get; set; } //personmore.enterdate , bronze - timestamp
        public string updateInfo { get; set; }
        public int flag { get; set; } //flag
        public string category { get; set; } //category //bronze - sourcetype
        public string categorydescription { get; set; } // personmore.categories
        public string subcategory { get; set; } //personmore.subcategory
        public bool deceased { get; set; } //personmore.descesed MAP ("No" , "YES")
        public string deceasedDate { get; set; } //personmore.deceasedDate
        public string name { get; set; } //fistname+ " "+ middleName + " " +lastname //bronze - name
        public string title { get; set; } //PersonMore.title
        public string firstName { get; set; } //personmore.primaryfirstname
        public string middleName { get; set; } //personmore.primarymiddlename
        public string lastName { get; set; } //personmore.primarylastname //bronze - lastnames
        public string gender { get; set; } //personemore.gender , bronze - gender
        public string originalScriptName { get; set; }
        public string sortKeyName { get; set; }
        public string program { get; set; }
        public string nationality { get; set; } //personmore.generalinformation.nationality
        public string citizenship { get; set; } //bronze -citizenships
        public string primarylocation { get; set; }//personmore.primarylocation

        public string father { get; set; } //bronze - parents
        public string mother { get; set; } //bronze - parents
        public string spouse { get; set; } //bronze -spousex
        public string basis { get; set; }
        public string summary { get; set; } //personmore.furtherinformation
        public double matchRate { get; set; } //matchrate

        public string alternateTitle { get; set; }//personmore.generalInfo //bronze - entity type
        public string businessDescription { get; set; }//personmore.generalInfo 
        public string website { get; set; }//personmore.generalInfo
        [XmlElement(ElementName = "datesOfBirth")]
        public DatesOfBirth datesOfBirth { get; set; } //personmore.dateofbirth , bronze - date of birth 

        [XmlElement(ElementName = "placesOfBirth")]
        public PlacesOfBirth placesOfBirth { get; set; }
        public string referenceType { get; set; }
        public List<Reference> references { get; set; }
        [XmlElement(ElementName = "addresses")]
        public Addresses addresses { get; set; }


        public Places places { get; set; } //personmore.countries //bronze-address remark

        [XmlElement(ElementName = "otherNames")]
        public OtherNames otherNames { get; set; }


        [XmlElement(ElementName = "roles")]
        public Roles roles { get; set; }


        [XmlArray("occupations")]
        [XmlArrayItem("string", Namespace = "http://schemas.microsoft.com/2003/10/Serialization/Arrays")]
        public List<string> occupations { get; set; }
        [XmlArray("children")]
        [XmlArrayItem("string", Namespace = "http://schemas.microsoft.com/2003/10/Serialization/Arrays")]
        public List<string> children { get; set; } //bronze - children
        public List<string> siblings { get; set; } //bronze - siblings
        public List<Identity> identities { get; set; } //personmore.idnumbers //bronze - pep type
        [XmlElement(ElementName = "contacts")]
        public Contacts contact { get; set; }
        [XmlArray("images")]
        [XmlArrayItem("string", Namespace = "http://schemas.microsoft.com/2003/10/Serialization/Arrays")]
        public List<string> images { get; set; } //personmore.image 
        public List<Link> links { get; set; } //bronze - links
        public List<Source> sources { get; set; } //strign in emarlad object in sapphire
        public List<string> originalscriptnames { get; set; } //personmore.originalscriptname //bronze - givenanme

        public List<Description> descriptions { get; set; } //personmore.descriptions //bronze - description

        public Person()
        {
            addresses = new Addresses();
            //addresses = new List<Address>();
            places = new Places();
            otherNames = new OtherNames();
            //otherNames = new List<Othername>();
            roles = new Roles();
            occupations = new List<string>();
            children = new List<string>();
            siblings = new List<string>();
            images = new List<string>();
            sources = new List<Source>();
            datesOfBirth = new DatesOfBirth();
            placesOfBirth = new PlacesOfBirth();
            references = new List<Reference>();
            identities = new List<Identity>();
            contact = new Contacts();
            links = new List<Link>();

        }

        [XmlRoot(ElementName = "occupations")]
        public class Occupations
        {
            [XmlElement(ElementName = "string", Namespace = "http://schemas.microsoft.com/2003/10/Serialization/Arrays")]
            public List<string> String { get; set; }
        }

        [XmlRoot(ElementName = "children")]
        public class Children
        {
            [XmlElement(ElementName = "string", Namespace = "http://schemas.microsoft.com/2003/10/Serialization/Arrays")]
            public List<string> String { get; set; }
        }

        [XmlRoot(ElementName = "datesOfBirth")]
        public class DatesOfBirth
        {
            [XmlElement(ElementName = "Person.Datesofbirth")]
            public PersonDatesOfBirth Dates { get; set; }
        }

        [XmlRoot(ElementName = "Datesofbirth")]
        public class PersonDatesOfBirth
        {
            [XmlElement(ElementName = "date")]
            public string Date { get; set; }

            [XmlElement(ElementName = "note")]
            public string Note { get; set; }
        }

        [XmlRoot(ElementName = "placesOfBirth")]
        public class PlacesOfBirth
        {
            [XmlElement(ElementName = "Person.Placesofbirth")]
            public PersonPlaceOfBirth Places { get; set; }
        }


        public class PersonPlaceOfBirth
        {
            [XmlElement(ElementName = "city")]
            public string City { get; set; }

            [XmlElement(ElementName = "country")]
            public string Country { get; set; }

            [XmlElement(ElementName = "note")]
            public string Note { get; set; }

            [XmlElement(ElementName = "region")]
            public string Region { get; set; }

            [XmlElement(ElementName = "text")]
            public string Text { get; set; }

            [XmlElement(ElementName = "type")]
            public string Type { get; set; }
        }

        public class Reference
        {
            public string name { get; set; }
            public string since { get; set; }
            public string to { get; set; }
            public string idInList { get; set; }
        }

        public class Places
        {
            [XmlElement(ElementName = "Person.Place")]
            public List<Place> PlaceList { get; set; }
        }


        public class Place
        {
            [XmlElement(ElementName = "country", IsNullable = true)]
            public string Country { get; set; }

            [XmlElement(ElementName = "type")]
            public string Type { get; set; }
        }

        [XmlRoot(ElementName = "otherNames")]
        public class OtherNames
        {
            [XmlElement(ElementName = "Person.Othername")]
            public PersonOtherName Name { get; set; }
        }

        public class PersonOtherName
        {
            [XmlElement(ElementName = "firstName", IsNullable = true)]
            public string FirstName { get; set; }

            [XmlElement(ElementName = "lastName", IsNullable = true)]
            public string LastName { get; set; }

            [XmlElement(ElementName = "middleName", IsNullable = true)]
            public string MiddleName { get; set; }

            [XmlElement(ElementName = "name")]
            public string Name { get; set; }

            [XmlElement(ElementName = "title", IsNullable = true)]
            public string Title { get; set; }

            [XmlElement(ElementName = "type")]
            public string Type { get; set; }
        }


        [XmlRoot(ElementName = "roles")]
        public class Roles
        {
            [XmlElement(ElementName = "Person.Role")]
            public List<Role> RoleList { get; set; }
        }

        public class Role
        {
            [XmlElement(ElementName = "category", IsNullable = true)]
            public string Category { get; set; }

            [XmlElement(ElementName = "country", IsNullable = true)]
            public string Country { get; set; }

            [XmlElement(ElementName = "from", IsNullable = true)]
            public string From { get; set; }

            [XmlElement(ElementName = "isCurrent")]
            public bool IsCurrent { get; set; }

            [XmlElement(ElementName = "since", IsNullable = true)]
            public string Since { get; set; }

            [XmlElement(ElementName = "status", IsNullable = true)]
            public string Status { get; set; }

            [XmlElement(ElementName = "title")]
            public string Title { get; set; }

            [XmlElement(ElementName = "to", IsNullable = true)]
            public string To { get; set; }

            [XmlElement(ElementName = "type", IsNullable = true)]
            public string Type { get; set; }
        }

        public class Identity
        {
            public string number { get; set; }
            public string country { get; set; }
            public string note { get; set; }
            public string type { get; set; }
        }

        public class Contacts
        {
            [XmlElement(ElementName = "Person.Contact")]
            public List<Contact> ContactList { get; set; }
        }

        public class Contact
        {
            [XmlElement(ElementName = "type")]
            public string Type { get; set; }

            [XmlElement(ElementName = "value")]
            public string Value { get; set; }
        }


        public class Description
        {
            public string description1 { get; set; }
            public string description2 { get; set; }
            public string description3 { get; set; }
        }

        [XmlRoot(ElementName = "sources")]
        public class Sources
        {
            [XmlElement(ElementName = "sourc")]
            public List<Source> SourceList { get; set; }
        }

        public class Source
        {
            [XmlElement(ElementName = "url")]
            public string url { get; set; }
            [XmlElement(ElementName = "categories")]
            public string categories { get; set; }
            [XmlElement(ElementName = "dates")]
            public string dates { get; set; }
        }

        [XmlRoot(ElementName = "addresses")]
        public class Addresses
        {
            [XmlElement(ElementName = "Address")]
            public List<Address> Address { get; set; }
        }

        [XmlRoot(ElementName = "Address")]
        public class Address
        {
            [XmlElement(ElementName = "line1")]
            public string Line1 { get; set; }

            [XmlElement(ElementName = "line2")]
            public string Line2 { get; set; }

            [XmlElement(ElementName = "line3")]
            public string Line3 { get; set; }

            [XmlElement(ElementName = "postalCode")]
            public string PostalCode { get; set; }

            [XmlElement(ElementName = "city")]
            public string City { get; set; }

            [XmlElement(ElementName = "county")]
            public string County { get; set; }

            [XmlElement(ElementName = "country")]
            public string Country { get; set; }

            [XmlElement(ElementName = "text")]
            public string Text { get; set; }

            [XmlElement(ElementName = "note")]
            public string Note { get; set; }
        }

        public class Link
        {
            public string Url { get; set; }
            public string Type { get; set; }
        }
    }
}
