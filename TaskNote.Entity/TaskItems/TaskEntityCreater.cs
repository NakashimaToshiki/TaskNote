﻿using Microsoft.Extensions.Logging;
using System;

namespace TaskNote.Entity.TaskItems
{
    public class TaskEntityCreater
    {
        private readonly ILogger _logger;
        private readonly IDateTimeOptions _time;

        public TaskEntityCreater(ILogger logger, IDateTimeOptions time)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _time = time ?? throw new ArgumentNullException(nameof(time));
        }

        public TaskItem Factory(int id, string title, string description, DateTime now)
        {
            try
            {
                return new TaskItem(id, now, title, description);
            }
            catch (Exception e)
            {
                _logger.LogWarning(e);
                return MissingTaskItem.Instance;
            }
        }

        public TaskItem Factory(int id, string title, string description) => Factory(id, title, description, _time.Now);
    }
}