using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskNote.Server.Entity.Tasks;
using TaskNote.Server.Entity.Users;
using System.Linq;

namespace TaskNote.Server.Entity.FrameworkCore
{
    public class TaskSession<TDbContext> : ITaskSession where TDbContext : DbContext, ITaskDbSet
    {
        private readonly IDbContextFactory<TDbContext> _dbFactory;
        private readonly IDateTimeOptions _datetime;

        public TaskSession(IDbContextFactory<TDbContext> dbFactory, IDateTimeOptions datetime)
        {
            _dbFactory = dbFactory ?? throw new ArgumentNullException(nameof(dbFactory));
            _datetime = datetime ?? throw new ArgumentNullException(nameof(datetime));
        }

        public async ValueTask<TaskEntity> GetTaskById(int id)
        {
            try
            {
                using var db = _dbFactory.CreateDbContext();
                return await db.Tasks.Include(_ => _.User).FirstOrDefaultAsync(_ => _.Id == id);
            }
            catch (Exception e)
            {
                throw new DatabaseException(e);
            }
        }

        public async ValueTask<IEnumerable<TaskEntity>> GetTasksByUserName(string username)
        {
            try
            {
                using var db = _dbFactory.CreateDbContext();
                return await db.Tasks.Include(_ => _.User).Where(_ => _.User.Name == username).ToListAsync();
            }
            catch (Exception e)
            {
                throw new DatabaseException(e);
            }
        }

        public async ValueTask<bool> Add(string username, string title, string description)
        {
            try
            {
                using var db = _dbFactory.CreateDbContext();
                var user = await db.Users.FirstAsync(_ => _.Name == username);
                db.Tasks.Add(new TaskEntity(user, _datetime.Now, _datetime.Now, title, description));
                return await db.SaveChangesAsync() > 0;
            }
            catch (Exception e)
            {
                throw new DatabaseException(e);
            }
        }
    }
}
