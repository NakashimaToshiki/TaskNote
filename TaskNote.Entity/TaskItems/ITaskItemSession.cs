using System.Threading.Tasks;

namespace TaskNote.Entity.TaskItems
{
    public interface ITaskItemSession
    {
        ValueTask<TaskItem> GetById(int id);

        ValueTask<bool> AllDelete();
    }
}
