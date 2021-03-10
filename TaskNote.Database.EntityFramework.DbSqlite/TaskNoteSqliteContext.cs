using Microsoft.EntityFrameworkCore;
using TaskNote.Strage;

namespace TaskNote.Database.EntityFramework.DbSqlite
{
    public class TaskNoteSqliteContext : TaskNoteDbContext
    {
        private readonly IStoragePath _storagePath; // ここライブラリに置き換えられるかも

        public TaskNoteSqliteContext(IStoragePath storagePath, DbContextOptions options) : base(options)
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
