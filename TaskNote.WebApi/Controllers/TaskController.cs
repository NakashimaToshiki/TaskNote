using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskNote.BackEnd.Entity.Tasks;

namespace TaskNote.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : Controller
    {
        private readonly ITaskSession _session;

        public TaskController(ITaskSession session)
        {
            _session = session ?? throw new ArgumentNullException(nameof(session));
        }

        [HttpGet("{id}")]
        public async Task<TaskEntity> Get(int id)
        {
            return await _session.GetTaskById(id);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Post(TaskEntity model)
        {
            await _session.Add("a","b","c");
            return Ok();
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Put(TaskEntity model)
        {
            await _session.Add("a", "b", "c");
            return Ok();
        }
    }
}
