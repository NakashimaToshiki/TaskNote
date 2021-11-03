using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TaskNote.Http;

namespace TaskNote.ApiClient.Net5
{
    public class TaskShortsApiClient : ITaskShortsApiClient
    {
        private readonly HttpClient _httpClient;

        public TaskShortsApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<TaskShortsResponse> GetTaskShortsResponseAsync(DateTime first, DateTime end)
        {
            if (first > end)
            {
                return null;
            }

            var response = await _httpClient.GetAsync($"/api/taskShorts/{first.ToString("u")}/{end.ToString("u")}");

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<TaskShortsResponse>();
        }
    }
}
