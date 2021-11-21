using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskNote.BackEnd.Entity.ClientTraceLogs;

namespace TaskNote.Entity.Sessions
{
    public interface IClientTraceLogSession
    {
        Task<ClientTraceLogEntity> GetById(int id);

        Task<IEnumerable<(int id, DateTime time)>> GetTimesById(int id);

        Task<bool> Add(ClientTraceLogEntity entity);

        Task<bool> RemoveById(int id);
    }

}
