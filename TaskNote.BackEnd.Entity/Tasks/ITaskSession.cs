using System.Threading.Tasks;
using System.Collections.Generic;

namespace TaskNote.BackEnd.Entity.Tasks
{
    public interface ITaskSession
    {
        ValueTask<TaskEntity> GetTaskById(int id);

        ValueTask<IEnumerable<TaskEntity>> GetTasksByUserName(string username);

        ValueTask<bool> Add(string username, string title, string description);
    }
}
