using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskNote.Entity.Sessions;
using System.Linq;
using AutoMapper;

namespace TaskNote.Entity.FrameworkCore
{
    public class UserSession<TDbContext> : IUserSession where TDbContext : DbContext, IUserDbSet
    {
        private readonly IDbContextFactory<TDbContext> _dbFactory;

        public UserSession(IDbContextFactory<TDbContext> dbFactory, IDateTimeOptions datetime)
        {
            _dbFactory = dbFactory ?? throw new ArgumentNullException(nameof(dbFactory));
        }

        public async Task<IList<UserEntity>> GetAllAsync()
        {
            try
            {
                using var db = _dbFactory.CreateDbContext();
                return await db.Users.ToListAsync();
            }
            catch (Exception e)
            {
                throw new DatabaseException(e);
            }
        }

        public async Task<UserEntity> GetByIdAsync(int id)
        {
            try
            {
                using var db = _dbFactory.CreateDbContext();
                return await db.Users.FindAsync(id);
            }
            catch (Exception e)
            {
                throw new DatabaseException(e);
            }
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            try
            {
                using var db = _dbFactory.CreateDbContext();
                var find = await db.Users.FindAsync(id);
                if (find == null) return false;
                db.Users.Remove(find);
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                throw new DatabaseException(e);
            }
        }

        public async Task<bool> PostAsync(UserEntity input)
        {
            try
            {
                using var db = _dbFactory.CreateDbContext();
                var find = await db.Users.FindAsync(input.Id);
                if (find != null) return false;
                await db.Users.AddAsync(input);
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
