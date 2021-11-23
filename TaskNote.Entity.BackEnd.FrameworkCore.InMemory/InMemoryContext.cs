using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using System.Linq;

namespace TaskNote.Entity.FrameworkCore.InMemory
{
    public class InMemoryContext : BaseContext
    {
        private readonly IEnumerable<IDbContextAddDammy> dammys;

        public InMemoryContext(IEnumerable<IDbContextAddDammy> dammys, DbContextOptions options) : base(options)
        {
            this.dammys = dammys ?? throw new ArgumentNullException(nameof(dammys));
        }

        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder) =>
            modelBuilder.Entity<TaskEntity>().HasData(
                new TaskEntity(1, DateTime.Now, DateTime.Now, "", "")
                );*/

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Guid.NewGuild().ToString()を使うと同じデータベースを参照しなくなって意図した動きにならない。
            optionsBuilder.UseInMemoryDatabase("dammy");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            dammys.ToList().ForEach(dammy => dammy.AddDammy(modelBuilder));
        }
    }
}
