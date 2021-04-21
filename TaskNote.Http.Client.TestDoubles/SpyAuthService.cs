using System;
using System.Threading.Tasks;

namespace TaskNote.Http.Client
{
    public class SpyAuthService : IAuthService
    {
        private readonly IAuthService _decorated;

        public SpyAuthService(IAuthService decorated)
        {
            _decorated = decorated ?? throw new ArgumentNullException(nameof(decorated));
        }

        public int GetAuthenticationCount { get; private set; }

        public async ValueTask<bool> GetAuthentication()
        {
            GetAuthenticationCount++;
            return await _decorated.GetAuthentication();
        }
    }
}
