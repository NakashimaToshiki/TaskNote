using RestSharp;

namespace TaskNote.Http.Client.Rest
{
    public class ClientFactory
    {
        public RestClient Factory(string baseUrl)
        {
            var ret = new RestClient()
            {
                FailOnDeserializationError = false,
                ThrowOnDeserializationError = false,
                ThrowOnAnyError = false
            };
            return ret;
        }
    }
}
