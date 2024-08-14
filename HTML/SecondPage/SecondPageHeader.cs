using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace generatePDF.HTML
{
    public partial class SecondPage
    {
        public const string HtmlHeader = @"<style>
    .header {
        width: 100%;
        text-align: center;
        left: 0mm;
        height: 40mm;
        /* Adjust height as needed */
        background-size: cover;
        background-position: center;
        margin-bottom: 10mm;
    }
    .header {
        top: 0;
        background-image: url('https://clara-compliance.com/wp-content/uploads/2024/05/header3.png'); /* Replace with your header image URL */
    }
    .scan
    {
        position:absolute;
        right:73px;
        top: 20px;
    }
    .date {
        position: absolute;
        right: 73px;
        top: 45px;
    }
    .matching-font {
        font-style: normal;
        font-size: 13.00px;
        font-weight: 400;
        font-family: Helvetica, Arial;
        letter-spacing: 3px;
    }
</style>
    <div class=""header"">
        <div>
            <scanId class=""scan matching-font"">Scan Id: [@HEADER.SCAN.VALUE]</scanId>
        </div>
       <div>
           <date class=""date matching-font"">Date: [@HEADER.DATE.VALUE]</date>
       </div>
    </div>

";
    }
}
