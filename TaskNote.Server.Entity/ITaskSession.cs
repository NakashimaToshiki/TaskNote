using System.Threading.Tasks;
using TaskNote.Server.Entity.Tasks;
using System.Collections.Generic;

namespace TaskNote.Server.Entity
{
    public interface ITaskSession
    {
        ValueTask<TaskEntity> GetTaskById(int id);

        ValueTask<IEnumerable<TaskEntity>> GetTasksByUserName(string username);

        ValueTask<bool> Add(string username, string title, string description);
    }
}
