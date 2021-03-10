using System.Threading.Tasks;

namespace TaskNote.Batch
{
    public interface IStartBatch
    {
        ValueTask<bool> Run();
    }
}
