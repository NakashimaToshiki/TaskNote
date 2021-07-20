using System;
using TaskNote.Server.Entity.Users;

namespace TaskNote.Server.Entity.Tasks
{
    public class NullTaskEntity : TaskEntity
    {
        public static NullTaskEntity Instance = new NullTaskEntity();

        protected NullTaskEntity() : base(NullUserEntity.Instance, DateTime.MinValue, DateTime.MinValue, "no title", "no description")
        {
        }
    }
}
