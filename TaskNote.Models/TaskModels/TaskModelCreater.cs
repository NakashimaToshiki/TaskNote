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

        public TaskModel Factory(string text, bool isComplted)
        {
            try
            {
                return new TaskModel(text, isComplted);
            }
            catch (Exception e)
            {
                _logger.LogError(e);
                return MissingTaskModel.Instance;
            }
        }
    }
}
