using Microsoft.Extensions.Logging;
using System;
using TaskNote.Server.Entity.Users;

namespace TaskNote.Server.Entity.Tasks
{
    public class TaskFactory
    {
        private readonly ILogger<TaskFactory> _logger;
        private readonly IDateTimeOptions _datetime;

        public TaskFactory(ILogger<TaskFactory> logger, IDateTimeOptions datetime)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _datetime = datetime ?? throw new ArgumentNullException(nameof(datetime));
        }

        public TaskEntity Create(UserEntity user, string title)
        {
            try
            {
                return new TaskEntity(user, _datetime.Now, _datetime.Now, title, "");
            }
            catch (Exception e)
            {
                _logger.LogError(e);
                return NullTaskEntity.Instance;
            }
        }
    }
}
