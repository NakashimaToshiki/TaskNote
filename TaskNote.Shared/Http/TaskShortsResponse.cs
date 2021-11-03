using System.Collections.Generic;
using TaskNote.Tasks;

namespace TaskNote.Http
{
    public class TaskShortsResponse
    {
        public ICollection<TaskShortModel> Tasks { get; set; } = new List<TaskShortModel>();
    }
}
