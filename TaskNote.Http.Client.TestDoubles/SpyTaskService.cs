using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskNote.Http.Client
{
    public class SpyTaskService : ITaskService
    {
        private readonly ITaskService decrated;

        public SpyTaskService(ITaskService decrated)
        {
            this.decrated = decrated ?? throw new ArgumentNullException(nameof(decrated));
        }

        // async書いてないけど動く？
        public ValueTask<IEnumerable<TaskNoteJsonBody>> AllGet()
        {
            return decrated.AllGet();
        }

        public ValueTask<TaskNoteJsonBody> GetById(int id)
        {
            return decrated.GetById(id);
        }

        public ValueTask<bool> PutAll(IEnumerable<TaskNoteJsonBody> body)
        {
            return decrated.PutAll(body);
        }

        public ValueTask<bool> PutById(TaskNoteJsonBody body)
        {
            return decrated.PutById(body);
        }
    }
}
