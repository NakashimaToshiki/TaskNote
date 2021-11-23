using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskNote.Entity.Sessions;
using System.Linq;

namespace TaskNote.Entity.FrameworkCore
{
    public class UserSession<TDbContext> : IUserSession where TDbContext : DbContext, IUserDbSet
    {
        private readonly IDbContextFactory<TDbContext> _dbFactory;

        public UserSession(IDbContextFactory<TDbContext> dbFactory, IDateTimeOptions datetime)
        {
            _dbFactory = dbFactory ?? throw new ArgumentNullException(nameof(dbFactory));
        }

        public async Task<IList<UserModel>> GetAll()
        {
            try
            {
                using var db = _dbFactory.CreateDbContext();
                return await db.Users.Cast<UserModel>().ToListAsync();
            }
            catch (Exception e)
            {
                throw new DatabaseException(e);
            }
        }

        public async Task<UserModel> GetById(int id)
        {
            try
            {
                using var db = _dbFactory.CreateDbContext();
                return await db.Users.FirstOrDefaultAsync(_ => _.Id == id);
            }
            catch (Exception e)
            {
                throw new DatabaseException(e);
            }
        }

        public async Task<bool> Post(UserModel input)
        {
            try
            {
                using var db = _dbFactory.CreateDbContext();
                await db.Users.AddAsync(new UserEntity()
                {
                    Id = input.Id,
                    Name = input.Name
                });
                return await db.SaveChangesAsync() > 0;
            }
            catch (Exception e)
            {
                throw new DatabaseException(e);
            }
        }

    }
}
