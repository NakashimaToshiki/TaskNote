using System;

namespace TaskNote.Entity.TaskItems
{
    public class MissingTaskEntity : TaskEntity
    {
        public static MissingTaskEntity Instance { get; } = new MissingTaskEntity();

        private MissingTaskEntity() : base(0, DateTime.MinValue, "Missing Title", "Missing Description")
        {
        }
    }
}
