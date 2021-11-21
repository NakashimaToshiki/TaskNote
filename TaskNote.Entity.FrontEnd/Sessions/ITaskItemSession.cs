using System.Threading.Tasks;

namespace TaskNote.Entity.Sessions
{
    public interface ITaskItemSession
    {
        Task<bool> Add(TaskEntity item);

        Task<TaskEntity> GetById(int id);

        Task<bool> AllDelete();
    }
}
