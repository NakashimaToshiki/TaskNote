using RestSharp;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace TaskNote.Http.Client.Rest
{
    public class LogFileUploadService : ILogFileUploadService
    {
        private readonly ClientFactory _clientFactory;
        private readonly IHttpUrl _url;
        private readonly IUserOptions _user;

        public LogFileUploadService(ClientFactory clientFactory, IHttpUrl url, IUserOptions user)
        {
            _clientFactory = clientFactory ?? throw new ArgumentNullException(nameof(clientFactory));
            _url = url ?? throw new ArgumentNullException(nameof(url));
            _user = user ?? throw new ArgumentNullException(nameof(user));
        }

        public async ValueTask<bool> Upload(string filePath, string text)
        {
            try
            {
                var client = _clientFactory.Factory(_url.SaverDomain);

                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(text);

                var request = new RestRequest(_url.LogEndPoint, Method.GET)
                    .AddUrlSegment("user_id", _user.UserId)
                    .AddFile(Path.GetFileName(filePath), bytes, filePath);

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
