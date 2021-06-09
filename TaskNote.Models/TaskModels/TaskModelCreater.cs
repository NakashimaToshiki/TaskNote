using Microsoft.Extensions.Logging;
using System;

namespace TaskNote.Models.TaskModels
{
    public class TaskModelCreater
    {
        private readonly ILogger _logger;

        public TaskModelCreater(ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public TaskModel Factory(string text, string description, bool isComplted)
        {
            try
            {
                return new TaskModel(text, description,isComplted);
            }
            catch (Exception e)
            {
                _logger.LogError(e);
                return MissingTaskModel.Instance;
            }
        }
    }
}
