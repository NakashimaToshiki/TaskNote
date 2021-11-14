using System;
using TaskNote.BackEnd.Entity.Users;
using TaskNote.Tasks;

namespace TaskNote.BackEnd.Entity.Tasks
{
    public class TaskEntity : TaskModel
    {
        public int UserId { get; protected set; }

        public virtual UserEntity User { get; set; }

        public override string ToString() => this.ToStringProperties();
    }
}
