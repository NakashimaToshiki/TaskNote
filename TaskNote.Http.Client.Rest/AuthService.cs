using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TaskNote.Http.Client.Rest
{
    public class AuthService : IAuthService
    {
        public async ValueTask<int> GetAuthentication()
        {
            try
            {
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
