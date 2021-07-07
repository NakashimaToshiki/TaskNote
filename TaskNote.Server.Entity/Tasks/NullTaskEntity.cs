using System;

namespace TaskNote.Server.Entity.Tasks
{
    public class NullTaskEntity : TaskEntity
    {
        public static NullTaskEntity Instance = new NullTaskEntity();

        protected NullTaskEntity() : base("null", DateTime.MinValue, DateTime.MinValue, "no title", "no description")
        {
        }
    }
}
