using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskNote.BackEnd.Entity.ClientTraceLogs;
using TaskNote.Entity.Sessions;

namespace TaskNote.Entity.Repositories
{
    public class ClientTraceLogRepository
    {
        private readonly ILogger<ClientTraceLogRepository> _logger;
        private readonly IClientTraceLogSession _session;

        public ClientTraceLogRepository(ILogger<ClientTraceLogRepository> logger, IClientTraceLogSession session)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _session = session ?? throw new ArgumentNullException(nameof(session));
        }

        public async Task<bool> Add(int id, byte[] content, DateTime createTime)
        {
            try
            {
                return await _session.Add(new ClientTraceLogEntity());
            }
            catch (Exception e)
            {
                _logger.LogWarning(e);
                return false;
            }
        }

        public async Task<byte[]> GetById(int id)
        {
            try
            {
                var entity = await _session.GetById(id);
                return entity.Content;
            }
            catch (Exception e)
            {
                _logger.LogWarning(e);
                return new byte[0];
            }
        }

        public async Task<IEnumerable<(int id, DateTime time)>> FindDateTimes(int userId)
        {
            try
            {
                return await _session.GetTimesById(userId);
            }
            catch (Exception e)
            {
                _logger.LogWarning(e);
                return new (int id, DateTime time)[0];
            }
        }
    }
}
