using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskNote.Server.Entity.ClientTraceLogs;

namespace TaskNote.Server.Entity.FrameworkCore
{
    public class ClientTraceLogSession<TDbContext> : IClientTraceLogSession where TDbContext : DbContext, IClientTraceLogDbSet
    {
        private readonly IDbContextFactory<TDbContext> _dbFactory;

        public ClientTraceLogSession(IDbContextFactory<TDbContext> dbFactory)
        {
            _dbFactory = dbFactory ?? throw new ArgumentNullException(nameof(dbFactory));
        }

        public async ValueTask<ClientTraceLogEntity> GetById(int id)
        {
            try
            {
                using var db = _dbFactory.CreateDbContext();
                return await db.ClientTraceLogs.FirstOrDefaultAsync(_ => _.Id == id);
            }
            catch (Exception e)
            {
                throw new DatabaseException(e);
            }
        }
    }
}
