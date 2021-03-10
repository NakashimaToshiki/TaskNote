using System;

namespace TaskNote.Database.TaskItems
{
    public class TaskItem : IEntity
    {
        public int Id { get; protected set; }

        public DateTime UpdateData { get; protected set; }

        public string Title { get; protected set; }

        public string Description { get; protected set; }

        public TaskItem(int id, DateTime updateData, string title, string description)
        {
            Id = id;
            UpdateData = updateData;
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Description = description ?? throw new ArgumentNullException(nameof(description));
        }
    }
}
