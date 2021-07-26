using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskNote.Server.Entity.ClientTraceLogs;

namespace TaskNote.Server.Models.Repositories
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

        public async ValueTask<bool> Add(int id, byte[] content, DateTime createTime)
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

        public async ValueTask<IEnumerable<(int id, DateTime time)>> FindDateTimes(int userId)
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
