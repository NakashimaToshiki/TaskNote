using System;
using System.Threading.Tasks;

namespace TaskNote.Http.Client
{
    public class SpyLogFileUploadService : ILogFileUploadService
    {
        private readonly ILogFileUploadService decrated;

        public SpyLogFileUploadService(ILogFileUploadService decrated)
        {
            this.decrated = decrated ?? throw new ArgumentNullException(nameof(decrated));
        }

        public int UploadCount { get; private set; }

        public ValueTask<bool> Upload(string filePath, string text)
        {
            UploadCount++;
            return decrated.Upload(filePath, text);
        }
    }
}
