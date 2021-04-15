using System.Threading.Tasks;

namespace TaskNote.Http.Client
{
    public interface ILogConfigDownloadService
    {
        ValueTask<byte[]> Download();
    }
}
