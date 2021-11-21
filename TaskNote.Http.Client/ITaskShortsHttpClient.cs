using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskNote.Entity;

namespace TaskNote.ApiClient
{
    public interface ITaskShortsApiClient
    {
        Task<ICollection<TaskShortModel>> GetTaskShortsResponseAsync(DateTime first, DateTime end);
    }

}
