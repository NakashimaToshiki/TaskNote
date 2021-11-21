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
    public class TaskController : Controller
    {
        private readonly ITaskSession _session;

        public TaskController(ITaskSession session)
        {
            _session = session ?? throw new ArgumentNullException(nameof(session));
        }

        [HttpGet("{id}")]
        public async Task<TaskModel> Get(int id)
        {
            return await _session.GetByIdAsync(id);
        }

        [HttpGet]
        public IEnumerable<TaskShortModel> GetsByUserName(string userName)
        {
            return _session.GetTasksByUserName(userName).Select(_ => new TaskShortModel()
            {
                Id = _.Id,
                Title = _.Title,
            }).ToList();
            // Castでもいいかも
        }

        [HttpPost()]
        public async Task<IActionResult> Post(TaskModel input)
        {
            if(await _session.PostAsync(input)) return NoContent();
            else return NotFound();
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Put(int id, TaskModel input)
        {
            if(await _session.PutAsync(id, input)) return NoContent();
            else return NotFound();
        }

        /*
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchForTitleAsync(int id, string title)
        {
            if (await _session.PatchForTitleAsync(id, title)) return NoContent();
            else return NotFound();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchForDescriptionAsync(int id, string description)
        {
            if (await _session.PatchForDescriptionAsync(id, description)) return NoContent();
            else return NotFound();
        }*/

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _session.DeleteAsync(id)) return NoContent();
            else return NotFound();
        }
    }
}
