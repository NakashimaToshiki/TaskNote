using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskNote.BackEnd.Entity.ClientTraceLogs
{
    public interface IClientTraceLogSession
    {
        ValueTask<ClientTraceLogEntity> GetById(int id);

        ValueTask<IEnumerable<(int id, DateTime time)>> GetTimesById(int id);

        ValueTask<bool> Add(ClientTraceLogEntity entity);

        ValueTask<bool> RemoveById(int id);
    }

}
