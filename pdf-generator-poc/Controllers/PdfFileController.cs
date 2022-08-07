using pdf_generator_poc.DTOs;
using Microsoft.AspNetCore.Mvc;
using pdf_generator_poc.Interfaces;

namespace pdf_generator_poc.Controllers
{
    [ApiController]
    [Route("[controller]/api")]
    public class PdfFileController : ControllerBase
    {
        private IPdfService<string> _service;

        public PdfFileController(IPdfService<string> service) => _service = service;

        [HttpPost("dink-to-pdf")]
        public async Task<IActionResult> CreatePdfDinkToPdf([FromBody] CreatedBy createdBy)
        {
            var result = await _service.CreatePdf(createdBy.Name);

            return Ok("PDF Created Successfully");
        }
    }
}
