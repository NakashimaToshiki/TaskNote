using System.Threading.Tasks;

namespace TaskNote.Entity.TaskItems
{
    public interface ITaskItemSession
    {
        ValueTask<bool> Add(TaskEntity item);

        ValueTask<TaskEntity> GetById(int id);

        ValueTask<bool> AllDelete();
    }
}
