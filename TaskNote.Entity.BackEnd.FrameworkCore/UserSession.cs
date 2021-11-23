using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using TaskNote.Entity.Sessions;

namespace TaskNote.Entity.FrameworkCore
{
    public class UserSession<TDbContext> : IUserSession where TDbContext : DbContext, IUserDbSet
    {
        private readonly IDbContextFactory<TDbContext> _dbFactory;

        public UserSession(IDbContextFactory<TDbContext> dbFactory, IDateTimeOptions datetime)
        {
            _dbFactory = dbFactory ?? throw new ArgumentNullException(nameof(dbFactory));
        }

        public async Task<UserEntity> GetById(int id)
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
