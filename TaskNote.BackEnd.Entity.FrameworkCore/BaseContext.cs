using Microsoft.EntityFrameworkCore;
using TaskNote.BackEnd.Entity.ClientTraceLogs;
using TaskNote.BackEnd.Entity.Tasks;
using TaskNote.BackEnd.Entity.Users;
using TaskNote.Users;

namespace TaskNote.BackEnd.Entity.FrameworkCore
{
    public abstract class BaseContext : DbContext, ITaskDbSet, IClientTraceLogDbSet, IUserDbSet
    {
        public DbSet<TaskEntity> Tasks { get; set; }

        public DbSet<ClientTraceLogEntity> ClientTraceLogs { get; set; }

        public DbSet<UserEntity> Users { get; set; }

        public BaseContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TaskMap());
            modelBuilder.ApplyConfiguration(new ClientTraceLogMap());
            modelBuilder.ApplyConfiguration(new UserMap());

            base.OnModelCreating(modelBuilder);
        }

    }
}
