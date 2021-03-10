using Microsoft.EntityFrameworkCore;
using TaskNote.Database.TaskItems;

namespace TaskNote.Database.EntityFramework
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
