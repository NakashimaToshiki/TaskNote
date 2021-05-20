using Microsoft.Extensions.Logging;
using System;

namespace TaskNote.Entity.TaskItems
{
    public class TaskEntityFactory
    {
        private readonly ILogger _logger;
        private readonly IDateTimeOptions _time;

        public TaskEntityFactory(ILogger logger, IDateTimeOptions time)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _time = time ?? throw new ArgumentNullException(nameof(time));
        }

        public TaskItem Instance(int id, string title, string description)
        {
            try
            {
                return new TaskItem(id, _time.Now, title, description);
            }
            catch (Exception e)
            {
                _logger.LogWarning(e);
                return MissingTaskItem.Instance;
            }
        }
    }
}
