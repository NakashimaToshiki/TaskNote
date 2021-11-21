using Microsoft.EntityFrameworkCore;

namespace TaskNote.Entity.FrameworkCore
{
    public class TaskNoteDbContext : DbContext, ITaskItemDbSet
    {
        public DbSet<TaskEntity> TaskItems { get; set; }

        public TaskNoteDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            // ここでロガーなどのオプションを設定する。
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TaskItemMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
