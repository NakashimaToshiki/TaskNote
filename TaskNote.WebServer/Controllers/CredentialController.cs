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
    public class CredentialController : Controller
    {
        public CredentialController()
        {

        }

        [HttpGet]
        public async Task<IActionResult> Upload()
        {
            return Ok();
        }
    }
}
