using RestSharp;
using System;
using System.Net;
using System.Threading.Tasks;

namespace TaskNote.Http.Client.Rest
{
    public class LogConfigDownloadService : ILogConfigDownloadService
    {
        private readonly ClientFactory _clientFactory;
        private readonly IHttpUrl _url;
        private readonly IUserOptions _user;

        public LogConfigDownloadService(ClientFactory clientFactory, IHttpUrl url, IUserOptions user)
        {
            _clientFactory = clientFactory ?? throw new ArgumentNullException(nameof(clientFactory));
            this._url = url ?? throw new ArgumentNullException(nameof(url));
            _user = user ?? throw new ArgumentNullException(nameof(user));
        }

        public async ValueTask<byte[]> Download()
        {
            try
            {
                var client = _clientFactory.Factory(_url.SaverDomain);

                var request = new RestRequest(_url.ConfigEndPoint, Method.GET)
                    .AddUrlSegment("user_id", _user.UserId);

                var response = await client.ExecuteAsync(request);
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new HttpRequestException(response.StatusCode);
                }

                return response.RawBytes;
            }
            catch (HttpRequestException e)
            {
                throw e;
            }
        }
    }
}
