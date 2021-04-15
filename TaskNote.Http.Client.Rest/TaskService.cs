using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace TaskNote.Http.Client.Rest
{
    public class TaskService : ITaskService
    {
        private readonly ClientFactory _clientFactory;
        private readonly IHttpUrl _url;
        private readonly IUserOptions _user;

        public TaskService(ClientFactory clientFactory, IHttpUrl url, IUserOptions user)
        {
            _clientFactory = clientFactory ?? throw new ArgumentNullException(nameof(clientFactory));
            _url = url ?? throw new ArgumentNullException(nameof(url));
            _user = user ?? throw new ArgumentNullException(nameof(user));
        }

        public async ValueTask<IEnumerable<TaskNoteJsonBody>> AllGet()
        {
            try
            {
                var client = _clientFactory.Factory(_url.SaverDomain);

                var request = new RestRequest(_url.TaskEndPoint, Method.GET)
                    .AddUrlSegment("user_id", _user.UserId);

                // TODO:配列でレスポンス取得できるか要検証
                var response = await client.ExecuteAsync<TaskNoteJsonBody[]>(request);
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new HttpRequestException(response.StatusCode);
                }

                return response.Data;
            }
            catch (HttpRequestException e)
            {
                throw e;
            }
        }

        public async ValueTask<TaskNoteJsonBody> GetById(int id)
        {
            try
            {
                var client = _clientFactory.Factory(_url.SaverDomain);

                var request = new RestRequest(_url.TaskEndPoint, Method.GET)
                    .AddUrlSegment("user_id", _user.UserId)
                    .AddParameter("id", id);

                var response = await client.ExecuteAsync<TaskNoteJsonBody>(request);
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new HttpRequestException(response.StatusCode);
                }

                return response.Data;
            }
            catch (HttpRequestException e)
            {
                throw e;
            }
        }

        public async ValueTask<bool> PutAll(IEnumerable<TaskNoteJsonBody> body)
        {
            try
            {
                var client = _clientFactory.Factory(_url.SaverDomain);

                var request = new RestRequest(_url.TaskEndPoint, Method.GET)
                    .AddUrlSegment("user_id", _user.UserId)
                    .AddJsonBody(body);

                var response = await client.ExecuteAsync(request);
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new HttpRequestException(response.StatusCode);
                }

                return true;
            }
            catch (HttpRequestException e)
            {
                throw e;
            }
        }

        public async ValueTask<bool> PutById(TaskNoteJsonBody body)
        {
            try
            {
                var client = _clientFactory.Factory(_url.SaverDomain);

                var request = new RestRequest(_url.TaskEndPoint, Method.GET)
                    .AddUrlSegment("user_id", _user.UserId)
                    .AddJsonBody(body);

                var response = await client.ExecuteAsync(request);
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new HttpRequestException(response.StatusCode);
                }

                return true;
            }
            catch (HttpRequestException e)
            {
                throw e;
            }
        }
    }
}
