using System;

namespace TaskNote.Entity
{
    public class TaskEntity : TaskModel
    {
        public override string ToString()
        {
            return this.ToStringProperties();
        }
    }
}
