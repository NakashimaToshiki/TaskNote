using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskNote.Entity.Sessions;

namespace TaskNote.Entity.FrameworkCore
{
    public class ClientTraceLogSession<TDbContext> : IClientTraceLogSession where TDbContext : DbContext, IClientTraceLogDbSet
    {
        private readonly IDbContextFactory<TDbContext> _dbFactory;

        public ClientTraceLogSession(IDbContextFactory<TDbContext> dbFactory)
        {
            _dbFactory = dbFactory ?? throw new ArgumentNullException(nameof(dbFactory));
        }

        public async Task<ClientTraceLogEntity> GetById(int id)
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

        public async Task<IEnumerable<(int id, DateTime time)>> GetTimesById(int id)
        {
            try
            {
                using var db = _dbFactory.CreateDbContext();

                var items = await db.ClientTraceLogs
                    .Include(_ => _.User).Where(_ => _.UserId == id).Select(_ => new { _.Id, _.CreateDate })
                    .ToListAsync();

                return items.Select(_ => (_.Id, _.CreateDate));
            }
            catch (Exception e)
            {
                throw new DatabaseException(e);
            }
        }

        public async Task<bool> Add(ClientTraceLogEntity entity)
        {
            try
            {
                using var db = _dbFactory.CreateDbContext();

                db.ClientTraceLogs.Add(entity);
                return await db.SaveChangesAsync() > 0;
            }
            catch (Exception e)
            {
                throw new DatabaseException(e);
            }
        }

        public async Task<bool> RemoveById(int id)
        {
            try
            {
                using var db = _dbFactory.CreateDbContext();

                var entity = await db.ClientTraceLogs.FirstAsync(_ => _.Id == id);
                db.ClientTraceLogs.Remove(entity);
                return await db.SaveChangesAsync() > 0;
            }
            catch (Exception e)
            {
                throw new DatabaseException(e);
            }
        }
    }
}
