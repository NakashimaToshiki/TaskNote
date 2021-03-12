using System.Threading.Tasks;

namespace TaskNote.Batch
{
    public class MainExitBatch : IExitBatch
    {
        public async ValueTask<bool> Run()
        {
            await Task.Delay(1);
            return true;
        }
    }
}
