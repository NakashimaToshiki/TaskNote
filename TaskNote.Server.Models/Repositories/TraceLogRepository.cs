using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskNote.Server.Entity.ClientTraceLogs;

namespace TaskNote.Server.Models.Repositories
{
    public class TraceLogRepository
    {
        private readonly ILogger<TraceLogRepository> _logger;
        private readonly IClientTraceLogSession _session;

        public TraceLogRepository(ILogger<TraceLogRepository> logger, IClientTraceLogSession session)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _session = session ?? throw new ArgumentNullException(nameof(session));
        }

        public async ValueTask<> GetAll()
        {

        }
    }
}
