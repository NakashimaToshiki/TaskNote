using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskNote.WebServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TaskController : Controller
    {
        public TaskController()
        {

        }

        [HttpGet("{username}/{id}")]
        public async Task<IActionResult> Get(string username, int id)
        {
            return Content($"{username}/{id}");
        }
    }
}
