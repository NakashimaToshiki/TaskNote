using Microsoft.EntityFrameworkCore;
using TaskNote.Server.Entity.Tasks;

namespace TaskNote.Server.Entity.FrameworkCore
{
    public abstract class BaseContext : DbContext, ITaskDbSet
    {
        public DbSet<TaskEntity> Tasks { get; set; }

        public BaseContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TaskMap());

            base.OnModelCreating(modelBuilder);
        }

    }
}
