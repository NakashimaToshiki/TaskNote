using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using TaskNote.Server.Entity.Tasks;

namespace TaskNote.Server.Models.Tasks
{
    public class TaskModelFactory
    {
        private readonly ILogger<TaskModelFactory> _logger;

        public TaskModelFactory(ILogger<TaskModelFactory> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public TaskModel Create(TaskEntity entity)
        {
            try
            {
                return new TaskModel()
                {
                    Title = entity.Title,
                    Description = entity.Description,
                };
            }
            catch (Exception e)
            {
                _logger.LogError(e);
                return NullTaskModel.Instance;
            }
        }
    }
}
