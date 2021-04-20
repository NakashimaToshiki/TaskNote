using System.Threading.Tasks;

namespace TaskNote
{
    public interface IBatch
    {
        ValueTask<bool> Run();
    }
}
