using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using TaskNote.Entity.Sessions;

namespace TaskNote.Entity.FrameworkCore
{
    public class TaskItemSession<TDbContext> : ITaskItemSession where TDbContext : DbContext, ITaskItemDbSet
    {
        private readonly IDbContextFactory<TDbContext> _dbFactory;

        public TaskItemSession(IDbContextFactory<TDbContext> dbFactory)
        {
            _dbFactory = dbFactory ?? throw new ArgumentNullException(nameof(dbFactory));
        }

        public async Task<TaskEntity> GetById(int id)
        {
            try
            {
                using var db = _dbFactory.CreateDbContext();
                return await db.TaskItems.FindAsync(id);
            }
            catch (Exception e)
            {
                throw new DatabaseException(e);
            }
        }

        public async Task<bool> AllDelete()
        {
            try
            {
                using var db = _dbFactory.CreateDbContext();
                db.TaskItems.RemoveRange(db.TaskItems);
                // たぶん、これは必要ない
                //await db.Database.ExecuteSqlInterpolatedAsync($"DELETE FROM sqlite_sequence WHERE name = 'tasks'");
                return await db.SaveChangesAsync() > 0;
            }
            catch (Exception e)
            {
                throw new DatabaseException(e);
            }
        }

        public async Task<bool> Add(TaskEntity item)
        {
            try
            {
                using var db = _dbFactory.CreateDbContext();
                db.TaskItems.Add(item);
                return await db.SaveChangesAsync() > 0;
            }
            catch (Exception e)
            {
                throw new DatabaseException(e);
            }
        }
    }
}
