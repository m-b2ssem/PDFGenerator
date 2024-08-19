using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using generatePDF.Functions;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace generatePDF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PdfController : ControllerBase
    {
        [HttpGet]
        [Route("generate")]
        public  IActionResult GeneratePdf([FromBody] PersonScanRequestResponse requestResponse)
        {
            Console.WriteLine("New request");
            string base64Str =  HelperPersonScanReport.GeneratePdfPersonScanResult(requestResponse.PersonScanRequest, requestResponse.PersonScanResponse);
            return Ok(base64Str);
        }

        [HttpGet]
        [Route("test")]

        public IActionResult Test() { 
            return Ok("hello word");
        }
    }
}
