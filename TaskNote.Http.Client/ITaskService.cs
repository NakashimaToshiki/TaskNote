using System.Collections.Generic;
using System.Threading.Tasks;
using TaskNote.Entity;

namespace TaskNote.Http.Client
{
    public interface ITaskService
    {
        Task<ICollection<TaskModel>> AllGet();

        Task<TaskModel> GetById(int id);

        Task<bool> PutAll(IEnumerable<TaskModel> body);

        Task<bool> PutById(TaskModel body);
    }
}
