using AutoMapper;
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
        private readonly IMapper _mapper;
        private readonly IDbContextFactory<TDbContext> _dbFactory;
        private readonly IDateTimeOptions _datetime;

        public TaskSession(IMapper mapper, IDbContextFactory<TDbContext> dbFactory, IDateTimeOptions datetime)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _dbFactory = dbFactory ?? throw new ArgumentNullException(nameof(dbFactory));
            _datetime = datetime ?? throw new ArgumentNullException(nameof(datetime));
        }

        public async Task<TaskModel> GetByIdAsync(int id)
        {
            try
            {
                using var db = _dbFactory.CreateDbContext();
                var recoed = await db.Tasks.FindAsync(id);
                return _mapper.Map<TaskModel>(recoed);
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
                // ここを見るとこのクラスでAutoMapperを使った方がいいかもしれない
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
                var find = await db.Tasks.FindAsync(input.Id);
                if (find != null) return false;
                var record = _mapper.Map<TaskEntity>(input);
                db.Tasks.Add(record);
                return await db.SaveChangesAsync() > 0;
            }
            catch (Exception e)
            {
                throw new DatabaseException(e);
            }
        }

        public async Task<bool> PatchAsync(TaskModel input)
        {
            try
            {
                using var db = _dbFactory.CreateDbContext();
                var find = await db.Tasks.FindAsync(input.Id);
                if (find == null) return false;
                _mapper.Map(input, find);
                await db.SaveChangesAsync();
                return true;
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
                if (find == null) return false;
                find.Title = title;
                await db.SaveChangesAsync();
                return true;
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
                if (find == null) return false;
                find.Description = description;
                await db.SaveChangesAsync();
                return true;
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
                var find = await db.Tasks.FindAsync(id);
                if (find == null) return false;
                db.Remove(find);
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                throw new DatabaseException(e);
            }
        }
    }
}
