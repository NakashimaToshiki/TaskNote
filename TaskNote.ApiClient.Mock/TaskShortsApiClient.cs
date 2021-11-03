using System;
using System.Threading.Tasks;
using TaskNote.Http;
using TaskNote.Tasks;

namespace TaskNote.ApiClient.Mock
{
    public class TaskShortsApiClient : ITaskShortsApiClient
    {
        public async Task<TaskShortsResponse> GetTaskShortsResponseAsync(DateTime first, DateTime end)
        {
            await Task.Yield();
            return new TaskShortsResponse()
            {
                Tasks = new TaskShortModel[]
                {
                    new TaskShortModel()
                    {
                        Id = 1,
                        Title = "title1",
                    },
                    new TaskShortModel()
                    {
                        Id = 2,
                        Title = "titile2",
                    },
                    new TaskShortModel()
                    {
                        Id = 3,
                        Title = "titile3",
                    },
                    new TaskShortModel()
                    {
                        Id = 4,
                        Title = "titile4",
                    },
                }
            };
        }
    }
}
