using System.Threading.Tasks;

namespace TaskNote.Http.Client
{
    public interface ILogFileUploadService
    {
        ValueTask<bool> Upload(string filePath, string text);
    }
}
