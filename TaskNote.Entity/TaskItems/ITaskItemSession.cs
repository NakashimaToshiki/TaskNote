using System.Threading.Tasks;

namespace TaskNote.Entity.TaskItems
{
    public interface ITaskItemSession
    {
        ValueTask<bool> Add(TaskItem item);

        ValueTask<TaskItem> GetById(int id);

        ValueTask<bool> AllDelete();
    }
}
