using System;

namespace TaskNote.Tasks
{
    public class NullTaskModel : TaskModel
    {
        public static NullTaskModel Instance { get; } = new NullTaskModel()
        {
            Id = 0,
            UpdateDate = DateTime.MinValue,
            Title = "null",
            Description = "null",
        };

        protected NullTaskModel()
        {
        }
    }
}
