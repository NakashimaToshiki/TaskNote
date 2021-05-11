using Microsoft.EntityFrameworkCore;
using TaskNote.Entity.TaskItems;

namespace TaskNote.Entity.FrameworkCore
{
    public class TaskNoteDbContext : DbContext, ITaskItemDbSet
    {
        public DbSet<TaskItem> TaskItems { get; }

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
