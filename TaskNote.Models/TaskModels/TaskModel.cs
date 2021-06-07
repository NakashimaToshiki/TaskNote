using System;

namespace TaskNote.Models.TaskModels
{

    public class TaskModel
    {
        public string Title { get; protected set; }

        public string Description { get; protected set; }

        public bool IsCompleted { get; set; }

        public TaskModel(string title, string description, bool isComplited)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            IsCompleted = IsCompleted;
        }
    }
}
