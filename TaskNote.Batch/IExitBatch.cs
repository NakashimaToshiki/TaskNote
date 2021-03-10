using System.Threading.Tasks;

namespace TaskNote.Batch
{
    public interface IExitBatch
    {
        ValueTask<bool> Run();
    }
}
