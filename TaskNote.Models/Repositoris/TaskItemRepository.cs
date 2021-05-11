using System;
using System.Collections.Generic;
using System.Text;
using TaskNote.Entity.TaskItems;

namespace TaskNote.Models.Repositoris
{
    public class TaskItemRepository
    {
        private readonly ITaskItemSession _session;

        public TaskItemRepository(ITaskItemSession session)
        {
            _session = session ?? throw new ArgumentNullException(nameof(session));
        }

        public void Add()
        {
        }
    }
}
