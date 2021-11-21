using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskNote.Entity;

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
        public Task<ICollection<TaskModel>> AllGet()
        {
            return decrated.AllGet();
        }

        public Task<TaskModel> GetById(int id)
        {
            return decrated.GetById(id);
        }

        public Task<bool> PutAll(IEnumerable<TaskModel> body)
        {
            return decrated.PutAll(body);
        }

        public Task<bool> PutById(TaskModel body)
        {
            return decrated.PutById(body);
        }
    }
}
