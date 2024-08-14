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
        [HttpPost]
        [Route("generate")]
        public  IActionResult GeneratePdf([FromBody] PersonScanRequestResponse requestResponse)
        {
            string base64Str =  HelperPersonScanReport.GeneratePdfPersonScanResult(requestResponse.PersonScanRequest, requestResponse.PersonScanResponse);
            return Ok(base64Str);
        }
    }
}
