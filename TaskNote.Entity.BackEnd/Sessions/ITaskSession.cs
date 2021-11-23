using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskNote.Entity.Sessions
{
    public interface ITaskSession
    {
        Task<TaskEntity> GetByIdAsync(int id);

        Task<IList<TaskShortModel>> GetTasksByUserName(string username);

        Task<bool> PostAsync(TaskModel input);

        Task<bool> PatchForTitleAsync(int id, string title);

        Task<bool> PatchForDescriptionAsync(int id, string description);

        Task<bool> PutAsync(int id, TaskModel input);

        Task<bool> DeleteAsync(int id);
    }
}
