using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Net;
using System.Net.Mime;
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

        [HttpGet]
        public async Task<FileContentResult> Download(int id)
        {
            return File(await _repository.GetById(id), MediaTypeNames.Application.Octet, WebUtility.HtmlEncode(id.ToString()));
        }

        // [FromForm(Name = "file")]属性を付与するとSwagger上にファイルをアップロードするボタンが消える
        [HttpPost]
        public async Task<IActionResult> Upload(int id, int screenName, [FromForm(Name = "file")] IFormFile file)
        {
            if (file == null && file.Length <= 0) return new StatusCodeResult(400);

            using var ms = new MemoryStream();
            await file.CopyToAsync(ms);

            await _repository.Add(id, ms.ToArray(), DateTime.Now);

            return Content($"({file.ContentType}) - {file.Length}bytes アップロード完了");
        }
    }
}
