using RestSharp;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace TaskNote.Http.Client.Rest
{
    public class LogFileUploadService : IUploadTraceLogService
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

        public async ValueTask<bool> Upload(string filePath)
        {
            try
            {
                var client = _clientFactory.Factory(_url.SaverDomain);

                var request = new RestRequest(_url.LogEndPoint, DataFormat.Json)
                    //.AddParameter("user_id", _user.UserId) // これは上手くいかなかった
                    //.AddQueryParameter("user_id", _user.UserId) // クエリはこっち
                    .AddUrlSegment("user_id", _user.UserId)
                    .AddFile(Path.GetFileName(filePath), filePath);

                var response = await client.ExecuteAsync(request, Method.POST);
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
