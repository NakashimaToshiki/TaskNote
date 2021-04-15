using RestSharp;
using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TaskNote.Http.Client.Rest
{
    public class AuthService : IAuthService
    {
        private readonly ClientFactory _clientFactory;
        private readonly IHttpUrl _url;

        public AuthService(ClientFactory clientFactory, IHttpUrl url)
        {
            _clientFactory = clientFactory ?? throw new ArgumentNullException(nameof(clientFactory));
            _url = url ?? throw new ArgumentNullException(nameof(url));
        }

        public async ValueTask<bool> GetAuthentication()
        {
            try
            {
                var client = _clientFactory.Factory(_url.SaverDomain);

                var response = await client.ExecuteAsync(new RestRequest(_url.SessionEndPoint));

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    // TODO:冷静に考えるとHttpStatusCode.Unauthorizedを受け取ったら、全クラスに同一のエラーメッセージが必要
                    // TODO:HttpStatusCodeによって規定のエラーメッセージが必要か？
                    var sb = new StringBuilder();
                    sb.Append("認証に失敗しました。");
                    switch (response.StatusCode)
                    {
                        case HttpStatusCode.Unauthorized:
                            sb.Append("ユーザーIDとパスワードを見直してください。");
                            break;
                        default:
                            // TODO:将来的にHttpRequestExceptionがあると必ずステータスコードをログに残すので不要かも
                            sb.Append($"ステータスコード：{response.StatusCode}");
                            break;
                    }
                    throw new HttpRequestException(response.StatusCode, sb.ToString());
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
