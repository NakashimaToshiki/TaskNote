using System;
using System.Collections.Generic;
using System.Text;

namespace TaskNote.Server.Entity.Tasks
{
    public class TaskEntity
    {
        public int Id { get; protected set; }

        public string UserName { get; protected set; }

        public DateTime CreatedDate { get; protected set; }

        public DateTime UpdateDate { get; protected set; }

        public string Title { get; protected set; }

        public string Description { get; protected set; }

        public bool IsCompleted { get; set; } = false;

        public TaskEntity(string userName, DateTime createdDate, DateTime updateDate, string title, string description)
        {
            UserName = userName ?? throw new ArgumentNullException(nameof(userName));
            CreatedDate = createdDate;
            UpdateDate = updateDate;
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Description = description ?? throw new ArgumentNullException(nameof(description));
        }

    }
}
