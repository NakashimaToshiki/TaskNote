using System;

namespace TaskNote.Server.Models.Tasks
{
    public class NullTaskModel : TaskModel
    {
        public static NullTaskModel Instance { get; } = new NullTaskModel()
        {
            DateTime = DateTime.MinValue,
            Title = "null",
            Description = "null",
        };

        protected NullTaskModel()
        {
        }
    }
}
