using System;
using TaskNote.Server.Entity.Users;

namespace TaskNote.Server.Entity.Tasks
{
    public class TaskEntity : IEntity
    {
        public int Id { get; protected set; }

        public int UserId { get; protected set; }

        public virtual UserEntity User { get; protected set; }

        public DateTime CreatedDate { get; protected set; }

        public DateTime UpdateDate { get; protected set; }

        public string Title { get; protected set; }

        public string Description { get; protected set; }

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
