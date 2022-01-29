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

namespace TaskNote.JQruery.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IMapper _mapper;
        private readonly IUserSession _session;

        public UserController(ILogger<UserController> logger, IMapper mapper, IUserSession session)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _session = session ?? throw new ArgumentNullException(nameof(session));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserModel>> GetById(int id)
        {
            var record = await _session.GetByIdAsync(id);
            if (record == null) return NotFound();
            return _mapper.Map<UserModel>(record);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IList<UserModel>>> GetAll()
        {
            var records = await _session.GetAllAsync();
            if (records.Count == 0) return NotFound();
            return _mapper.Map<UserModel[]>(records);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await _session.DeleteByIdAsync(id)) return NotFound();
            return NoContent();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Post(UserModel input)
        {
            var record = _mapper.Map<UserEntity>(input);
            if (!await _session.PostAsync(record)) return Conflict();
            return CreatedAtAction(nameof(GetById), new { input.Id }, input);
        }
    }
}

