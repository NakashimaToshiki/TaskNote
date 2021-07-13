using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskNote.Server.Entity.Users;

namespace TaskNote.Server.Entity.FrameworkCore
{
    public class UserSession<TDbContext> : IUserSession where TDbContext : DbContext, IUserDbSet
    {
        private readonly IDbContextFactory<TDbContext> _dbFactory;

        public UserSession(IDbContextFactory<TDbContext> dbFactory, IDateTimeOptions datetime)
        {
            _dbFactory = dbFactory ?? throw new ArgumentNullException(nameof(dbFactory));
        }

        public async ValueTask<UserEntity> GetById(int id)
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
    }
}
