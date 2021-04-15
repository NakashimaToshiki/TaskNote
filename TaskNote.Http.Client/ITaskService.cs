using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskNote.Http.Client
{
    public interface ITaskService
    {
        ValueTask<IEnumerable<TaskNoteJsonBody>> AllGet();

        ValueTask<TaskNoteJsonBody> GetById(int id);

        ValueTask<bool> PutAll(IEnumerable<TaskNoteJsonBody> body);

        ValueTask<bool> PutById(TaskNoteJsonBody body);
    }
}
