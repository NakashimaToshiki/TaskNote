using System.Threading.Tasks;

namespace TaskNote.Server.Entity.ClientTraceLogs
{
    public interface IClientTraceLogSession
    {
        ValueTask<ClientTraceLogEntity> GetById(int id);
    }

}
