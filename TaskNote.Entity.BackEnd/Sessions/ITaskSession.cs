using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskNote.Entity.Sessions
{
    public interface ITaskSession
    {
        Task<TaskEntity> GetByIdAsync(int id);

        Task<IList<TaskShortModel>> GetTasksByUserId(int id);

        Task<bool> PostAsync(TaskEntity input);

        Task<bool> PatchForTitleAsync(int id, string title);

        Task<bool> PatchForDescriptionAsync(int id, string description);

        Task<bool> PutAsync(int id, TaskEntity input);

        Task<bool> DeleteAsync(int id);
    }
}
