using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TaskNote.Tasks;

namespace TaskNote.BackEnd.Entity
{
    public static class EntityExtensions
    {
        public static TaskNote.Http.TaskShortsResponse MapTaskShortsResponse(this ICollection<Tasks.TaskEntity> me)
        {
            return new TaskNote.Http.TaskShortsResponse()
            {
                Tasks = me.Cast<TaskShortModel>().ToList()
            };
        }
    }
}
