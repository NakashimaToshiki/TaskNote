using System;
using TaskNote.BackEnd.Entity.Users;
using TaskNote.Tasks;

namespace TaskNote.BackEnd.Entity.Tasks
{
    public class TaskEntity : TaskModel
    {
        public int UserId { get; protected set; }

        public virtual UserEntity User { get; protected set; }

        public DateTime CreatedDate { get; protected set; }

        public bool IsCompleted { get; set; } = false;

        public TaskEntity(UserEntity user, DateTime createdDate, DateTime updateDate, string title, string description)
        {
            User = user ?? throw new ArgumentNullException(nameof(user));
            UserId = user.Id;
            CreatedDate = createdDate;
            UpdateDate = updateDate;
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Description = description ?? throw new ArgumentNullException(nameof(description));
        }

        public override string ToString() => this.ToStringProperties();
    }
}
