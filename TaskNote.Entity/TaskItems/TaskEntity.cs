using System;
using TaskNote.Shared;

namespace TaskNote.Entity.TaskItems
{
    public class TaskEntity : IEntity
    {
        public int Id { get; protected set; }

        public DateTime UpdateData { get; protected set; }

        public string Title { get; protected set; }

        public string Description { get; protected set; }

        public bool IsCompleted { get; set; }

        public TaskEntity(int id, DateTime updateData, string title, string description)
        {
            Id = id;
            UpdateData = updateData;
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Description = description ?? throw new ArgumentNullException(nameof(description));
        }

        public override string ToString()
        {
            return this.ToStringProperties();
        }
    }
}
