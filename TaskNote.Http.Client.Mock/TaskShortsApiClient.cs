using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskNote.Entity;

namespace TaskNote.ApiClient.Mock
{
    public class TaskShortsApiClient : ITaskShortsApiClient
    {
        public async Task<ICollection<TaskShortModel>> GetTaskShortsResponseAsync(DateTime first, DateTime end)
        {
            await Task.Yield();
            return new TaskShortModel[]
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
                };
        }
    }
}
