using System;
using System.Threading.Tasks;

namespace TaskNote.Http.Client
{
    public class SpyLogConfigDownloadService : ILogConfigDownloadService
    {
        private readonly ILogConfigDownloadService _decorated;

        public SpyLogConfigDownloadService(ILogConfigDownloadService decorated)
        {
            _decorated = decorated ?? throw new ArgumentNullException(nameof(decorated));
        }

        public int DownloadCount { get; private set; }

        public async ValueTask<byte[]> Download()
        {
            DownloadCount++;
            return await _decorated.Download();
        }
    }
}
