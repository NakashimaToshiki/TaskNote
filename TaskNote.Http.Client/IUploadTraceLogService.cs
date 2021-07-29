using System.Threading.Tasks;

namespace TaskNote.Http.Client
{
    public interface IUploadTraceLogService
    {
        ValueTask<bool> Upload(string filePath);
    }
}
