using System;
using System.Collections.Generic;
using System.Text;
using TaskNote.Entity.TaskItems;

namespace TaskNote.Entity.Arranges
{
    public interface ITaskEntityArrange
    {
        TimeSpan Offset { get; }
        TaskItem Generate();
    }


}
