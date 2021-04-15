using RestSharp;
using RestSharp.Authenticators;

namespace TaskNote.Http.Client.Rest
{
    public class ClientFactory
    {
        private readonly IUserOptions _user;

        public ClientFactory(IUserOptions user)
        {
            _user = user ?? throw new System.ArgumentNullException(nameof(user));
        }

        public RestClient Factory(string baseUrl)
        {
            var ret = new RestClient()
            {
                Authenticator = new HttpBasicAuthenticator(_user.UserId, _user.Password),
                FailOnDeserializationError = false,
                ThrowOnDeserializationError = false,
                ThrowOnAnyError = false
            };
            return ret;
        }
    }
}
