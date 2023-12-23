using System.Net;
using FileEx.Server.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    [ApiController]
    [Route("/")]
    public class FileController(IFileService fileService) : Controller
    {
        private readonly IFileService _fileService = fileService;

        // GET: FileController
        [HttpGet]
        public HttpStatusCode Index()
        {
            return HttpStatusCode.OK;
        }

        [HttpPost]
        [Route(nameof(IFileService.GetDirectory))]
        public IActionResult GetDirectory(string path)
        {
            try
            {
                return Ok(_fileService.GetDirectory(path));
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

    }
}
