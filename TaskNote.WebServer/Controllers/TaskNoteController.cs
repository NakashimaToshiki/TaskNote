using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskNote.Http;

/*
namespace TaskNote.WebServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskNoteController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<TaskNoteController> _logger;

        public TaskNoteController(ILogger<TaskNoteController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public IEnumerable<TaskNoteJsonBody> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new TaskNoteJsonBody
            {
                date = DateTime.Now.AddDays(index),
                titile = rng.Next(-20, 55),
                context = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
*/