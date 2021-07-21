using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskNote.Server.Models.Repositories;

namespace TaskNote.WebServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientTraceLogController : Controller
    {
        private readonly ClientTraceLogRepository _repository;

        public ClientTraceLogController(ClientTraceLogRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        /*
        [HttpGet]
        public async Task<IEnumerable<FileContentResult>> DonwloadById(int id)
        {
            _repository.
            return Content($"download完了");
        }*/

        [HttpPost]
        public async Task<IActionResult> Upload(int id, [FromForm(Name = "file")] IFormFile file)
        {
            if (file == null && file.Length <= 0) return new StatusCodeResult(400);



            return Content($"({file.ContentType}) - {file.Length}bytes アップロード完了");
        }
    }
}
