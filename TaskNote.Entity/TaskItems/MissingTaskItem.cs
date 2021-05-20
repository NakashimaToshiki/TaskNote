using System;
using System.Collections.Generic;
using System.Text;

namespace TaskNote.Entity.TaskItems
{
    public class MissingTaskItem : TaskItem
    {
        public static MissingTaskItem Instance { get; } = new MissingTaskItem();

        private MissingTaskItem() : base(0, DateTime.MinValue, "", "")
        {
        }
    }
}
