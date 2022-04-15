using AutoMapper;
using Microsoft.AspNetCore.Http;
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
    [Route("api/[controller]")]
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<TaskModel>> GetById(int id)
        {
            var record = await _session.GetByIdAsync(id);
            if (record == null) return NoContent();
            return record;
        }

        [HttpPatch]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Patch(TaskModel input)
        {
            if (!await _session.PatchAsync(input)) return NotFound();
            else return CreatedAtAction(nameof(GetById), new { input.Id }, input);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await _session.DeleteAsync(id)) return NoContent();
            return NoContent();
        }

        [HttpGet("userid/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<IList<TaskShortModel>>> GetsByUserId(string id)
        {
            var records = await _session.GetTasksByUserId(id);
            if (records.Count == 0) return NoContent();
            return records.ToList();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Post(TaskModel input)
        {
            if (!await _session.PostAsync(input)) return Conflict();
            return CreatedAtAction(nameof(GetById), new { input.Id }, input);
        }
    }
}
