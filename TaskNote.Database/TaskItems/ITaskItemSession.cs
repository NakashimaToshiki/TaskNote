using System.Threading.Tasks;

namespace TaskNote.Database.TaskItems
{
    public interface ITaskItemSession
    {
        ValueTask<TaskItem> GetById(int id);

        ValueTask<bool> AllDelete();
    }
}
