using System;
using System.Threading.Tasks;

namespace TaskNote.Http.Client
{
    public class SpyLogFileUploadService : IUploadTraceLogService
    {
        private readonly IUploadTraceLogService decrated;

        public SpyLogFileUploadService(IUploadTraceLogService decrated)
        {
            this.decrated = decrated ?? throw new ArgumentNullException(nameof(decrated));
        }

        public int UploadCount { get; private set; }

        public ValueTask<bool> Upload(string filePath)
        {
            UploadCount++;
            return decrated.Upload(filePath);
        }
    }
}
