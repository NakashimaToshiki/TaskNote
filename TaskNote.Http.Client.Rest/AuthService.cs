using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

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

        public async ValueTask<int> GetAuthentication()
        {
            try
            {
                _clientFactory.Factory(_url.SaverDomain);

               // var request = new RestRequest(_url.SaverDomain, DataFormat.Json)
                    
                return 1;
            }
            catch (HttpRequestException e)
            {
                throw e;
            }
            catch (NotSupportedException e)
            {
                throw e;
            }
            /*
            catch (JsonException e)
            {
            }*/
        }
    }
}
