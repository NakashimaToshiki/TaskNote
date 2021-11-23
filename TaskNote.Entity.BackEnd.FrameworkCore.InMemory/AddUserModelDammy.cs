using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace TaskNote.Entity.FrameworkCore.InMemory
{
    public class AddUserModelDammy : IDbContextAddDammy
    {
        private readonly UserModelDammy _dammy;

        public AddUserModelDammy(UserModelDammy dammy)
        {
            _dammy = dammy ?? throw new ArgumentNullException(nameof(dammy));
        }

        public void AddDammy(BaseContext db)
        {
            _dammy.Dammys.ToList().ForEach(d => db.Users.Add(new UserEntity()
            {
                Id = d.Id,
                Name = d.Name
            }));
        }

        public void AddDammy(ModelBuilder modelBuilder)
        {
            var items = _dammy.Dammys.Select(d => new UserEntity()
            {
                Id = d.Id,
                Name = d.Name
            });
            modelBuilder.Entity<UserEntity>().HasData(items);
        }
    }
}
