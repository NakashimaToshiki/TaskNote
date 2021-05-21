using System.Threading.Tasks;

namespace TaskNote.Platform.Batchs
{
    public interface IStartBatch
    {
        ValueTask<bool> RunAsync();
    }
}
