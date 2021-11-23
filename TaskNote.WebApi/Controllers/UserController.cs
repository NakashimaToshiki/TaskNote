using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskNote.Entity;
using TaskNote.Entity.Sessions;

namespace TaskNote.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserSession _session;

        public UserController(ILogger<UserController> logger, IUserSession session)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _session = session ?? throw new ArgumentNullException(nameof(session));
        }

        [HttpGet("{id}")]
        public async Task<UserModel> GetById(int id)
        {
            return await _session.GetById(id);
        }

        [HttpGet]
        public async Task<IList<UserModel>> GetAll()
        {
            return await _session.GetAll();
        }

        [HttpPost]
        public async Task<ActionResult> Post(UserModel input)
        {
            await _session.Post(input);
            return Ok();
        }
    }
}
