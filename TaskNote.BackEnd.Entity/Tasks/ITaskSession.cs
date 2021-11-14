using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using TaskNote.Tasks;

namespace TaskNote.BackEnd.Entity.Tasks
{
    public interface ITaskSession
    {
        Task<TaskEntity> GetByIdAsync(int id);

        IQueryable<TaskEntity> GetTasksByUserName(string username);

        Task<bool> PostAsync(TaskModel input);

        Task<bool> PatchForTitleAsync(int id, string title);

        Task<bool> PatchForDescriptionAsync(int id, string description);

        Task<bool> PutAsync(int id, TaskModel input);

        Task<bool> DeleteAsync(int id);
    }
}
