using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskNote.Entity.Sessions;

namespace TaskNote.Entity.FrameworkCore
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

        public async Task<TaskEntity> GetByIdAsync(int id)
        {
            try
            {
                using var db = _dbFactory.CreateDbContext();
                return await db.Tasks.Include(_ => _.User).SingleOrDefaultAsync(_ => _.Id == id);
            }
            catch (Exception e)
            {
                throw new DatabaseException(e);
            }
        }

        public async Task<IList<TaskShortModel>> GetTasksByUserId(int id)
        {
            try
            {
                using var db = _dbFactory.CreateDbContext();
                return await db.Tasks.Include(_ => _.User).Where(_ => _.User.Id == id).Select(task => new TaskShortModel()
                {
                    Id = task.Id,
                    Title = task.Title
                }).ToListAsync();
            }
            catch (Exception e)
            {
                throw new DatabaseException(e);
            }
        }

        public async Task<bool> PostAsync(TaskModel input)
        {
            try
            {
                using var db = _dbFactory.CreateDbContext();
                db.Add(input);
                return await db.SaveChangesAsync() > 0;
            }
            catch (Exception e)
            {
                throw new DatabaseException(e);
            }
        }

        public async Task<bool> PutAsync(int id, TaskModel input)
        {
            try
            {
                using var db = _dbFactory.CreateDbContext();
                var find = await db.Tasks.FindAsync(id);
                find.Id = input.Id;
                find.Title = input.Title;
                find.Description = input.Description;
                find.IsCompleted = input.IsCompleted;
                find.UpdateDate = input.UpdateDate;
                find.CreatedDate = input.CreatedDate;

                return await db.SaveChangesAsync() > 0;
            }
            catch (Exception e)
            {
                throw new DatabaseException(e);
            }
        }

        public async Task<bool> PatchForTitleAsync(int id, string title)
        {
            try
            {
                using var db = _dbFactory.CreateDbContext();
                var find = await db.Tasks.FindAsync(id);
                find.Title = title;
                return await db.SaveChangesAsync() > 0;
            }
            catch (Exception e)
            {
                throw new DatabaseException(e);
            }
        }

        public async Task<bool> PatchForDescriptionAsync(int id, string description)
        {
            try
            {
                using var db = _dbFactory.CreateDbContext();
                var find = await db.Tasks.FindAsync(id);
                find.Description = description;
                return await db.SaveChangesAsync() > 0;
            }
            catch (Exception e)
            {
                throw new DatabaseException(e);
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                using var db = _dbFactory.CreateDbContext();
                db.Remove(await db.Tasks.FindAsync(id));
                return await db.SaveChangesAsync() > 0;

            }
            catch (Exception e)
            {
                throw new DatabaseException(e);
            }
        }
    }
}
