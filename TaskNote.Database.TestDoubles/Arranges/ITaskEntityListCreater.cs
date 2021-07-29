using System;
using System.Collections.Generic;
using System.Text;
using TaskNote.Entity.TaskItems;

namespace TaskNote.Entity.Arranges
{
    public interface ITaskEntityListCreater
    {
        ITaskEntityArrange Task { get; }

        TaskEntity Generater();
    }

    public abstract class BaseTaskEntityListCreater : ITaskEntityListCreater
    {
        private readonly TaskEntityCreater _creater;

        public ITaskEntityArrange Task { get; }

        public BaseTaskEntityListCreater(TaskEntityCreater creater)
        {
            _creater = creater ?? throw new ArgumentNullException(nameof(creater));
        }

        public TaskEntity Generater()
        {
            return _creater.Factory(Task.Id, Task.Title, Task.Description);
        }
    }
}
