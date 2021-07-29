using Microsoft.EntityFrameworkCore;
using System;
using TaskNote.Server.Entity.Tasks;

namespace TaskNote.Server.Entity.FrameworkCore.InMemory
{
    public class InMemoryContext : BaseContext
    {
        public InMemoryContext(DbContextOptions options) : base(options)
        {
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
    }
}
