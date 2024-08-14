using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace generatePDF.HTML
{
    public partial class SecondPage
    {
        public const string HtmlFooter = @"<style>
    .footer {
        width: 100%;
        text-align: center;
        left: 0mm;
        height: 50mm; /* Adjust height as needed */
        background-size: cover;
        background-position: center;
    }



    .footer {
        bottom: 0;
        background-image: url('https://clara-compliance.com/wp-content/uploads/2024/05/footer3.png'); /* Replace with your footer image URL */
    }
</style>
<div class=""footer""></div>";
    }
}
