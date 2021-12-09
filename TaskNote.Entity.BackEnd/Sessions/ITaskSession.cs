using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskNote.Entity.Sessions
{
    public interface ITaskSession
    {
        Task<TaskModel> GetByIdAsync(int id);

        Task<IList<TaskShortModel>> GetTasksByUserId(int id);

        Task<bool> PostAsync(TaskModel input);

        Task<bool> PatchAsync(TaskModel input);

        Task<bool> DeleteAsync(int id);
    }
}
