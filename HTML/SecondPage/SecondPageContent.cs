using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace generatePDF.HTML
{
    public partial class SecondPage
    {
        public const string HtmlContent = @"<div id=""content"">
    <div class=""page"">
        <div class=""custom-content"">
            <div class=""row profile"" style=""border-radius: 27px"">
                <img  src=""[image.url]"" style=""margin-left:10px;""  alt=""Profile Image"">
                <div class=""col-3 cc"">
                    <h4>[@first-name]</h4>
                    <h4>[@last-name]</h4>
                    <h6>Match Rate: [Match-rate]</h6>
                </div>
                <div class=""col-3 dd"" >
                    <p><i class=""fab fa-twitter""></i> : [@twitter-account-name]</p>
                    <p><i class=""fab fa-facebook""></i> : [@facebook-account-name]</p>
                    <p><i class=""fab fa-instagram""></i> : [@instagram-account-name]</p>
                </div>
            </div>
            <table class=""table"">
                <thead>
                    <tr></tr>
                </thead>
                <tbody>
                    <tr class=""matching-font"">
                        <th class=""matching-font"" scope=""row"">Adresse</th>
                        <td>[@adresse]</td>
                    </tr>
                    <tr class=""matching-font"">
                        <th class=""matching-font"" scope=""row"">Citizenship</th>
                        <td>[@citizenship]</td>
                    </tr>
                    <tr class=""matching-font"">
                        <th class=""matching-font"" scope=""row"">Date of birth</th>
                        <td>[@date-of-birth]</td>
                    </tr>
                    <tr class=""matching-font"">
                        <th class=""matching-font"" scope=""row"">Place of birth</th>
                        <td>[@place-of-birth]</td>
                    </tr>
                    <tr class=""matching-font"">
                        <th class=""matching-font"" scope=""row"">Father</th>
                        <td>[@father]</td>
                    </tr>
                    <tr class=""matching-font"">
                        <th class=""matching-font"" scope=""row"">Mother</th>
                        <td>[@mother]</td>
                    </tr>
                    <tr class=""matching-font"">
                        <th class=""matching-font"" scope=""row"">Childern</th>
                        <td>[@children]</td>
                    </tr>
                    <tr class=""matching-font"">
                        <th class=""matching-font"" scope=""row"">Occupations</th>
                        <td>[@occupations]</td>
                    </tr>
                    <tr class=""matching-font"">
                        <th class=""matching-font"" scope=""row"">Other names</th>
                        <td>[@other names]</td>
                    </tr>
                    <tr class=""matching-font"">
                        <th class=""matching-font"" scope=""row"">Type</th>
                        <td>[@type]</td>
                    </tr>
                    <tr class=""matching-font"">
                        <th class=""matching-font"" scope=""row"">Roles</th>
                        <td>[@roles]</td>
                    </tr>
                    <tr class=""matching-font"">
                        <th class=""matching-font"" scope=""row"">residnetials</th>
                        <td>[@residentials]</td>
                    </tr>
                    <tr class=""matching-font"">
                        <th class=""matching-font"" scope=""row"">Sources</th>
                        <td>[@sources]</td>
                    </tr>
                    <tr class=""matching-font"">
                        <th class=""matching-font"" scope=""row"">Summary</th>
                        <td>[@summary]</td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</div>";
    }
}
