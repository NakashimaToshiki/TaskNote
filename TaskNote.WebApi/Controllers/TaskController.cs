using AutoMapper;
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
        private readonly ILogger<TaskController> _logger;
        private readonly IMapper _mapper;
        private readonly ITaskSession _session;

        public TaskController(ILogger<TaskController> logger, IMapper mapper, ITaskSession session)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _session = session ?? throw new ArgumentNullException(nameof(session));
        }

        [HttpGet("{id}")]
        public async Task<TaskModel> GetById(int id)
        {
            var entity = await _session.GetByIdAsync(id);
            return _mapper.Map<TaskEntity, TaskModel>(entity);
        }

        [HttpGet("userid/{id}")]
        public async Task<IEnumerable<TaskShortModel>> GetsByUserId(int id)
        {
            return await _session.GetTasksByUserId(id);
        }

        [HttpPost()]
        public async Task<IActionResult> Post(TaskModel input)
        {
            var entity = _mapper.Map<TaskModel, TaskEntity>(input);
            if (await _session.PostAsync(entity)) return NoContent();
            else return NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, TaskModel input)
        {
            var entity = _mapper.Map<TaskModel, TaskEntity>(input);
            if (await _session.PutAsync(id, entity)) return NoContent();
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
