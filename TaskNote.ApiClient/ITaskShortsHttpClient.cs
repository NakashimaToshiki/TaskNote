using System;
using System.Threading.Tasks;
using TaskNote.Http;

namespace TaskNote.ApiClient
{
    public interface ITaskShortsApiClient
    {
        Task<TaskShortsResponse> GetTaskShortsResponseAsync(DateTime first, DateTime end);
    }

}
