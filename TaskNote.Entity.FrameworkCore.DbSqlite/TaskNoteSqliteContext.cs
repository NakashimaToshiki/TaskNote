using Microsoft.EntityFrameworkCore;

namespace TaskNote.Entity.FrameworkCore.DbSqlite
{
    public class TaskNoteSqliteContext : TaskNoteDbContext
    {
        private readonly IDatabaseOptions _storagePath; // ここライブラリに置き換えられるかも

        public TaskNoteSqliteContext(IDatabaseOptions storagePath, DbContextOptions options) : base(options)
        {
            _storagePath = storagePath ?? throw new System.ArgumentNullException(nameof(storagePath));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={_storagePath.DatabaseFilePath}");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
