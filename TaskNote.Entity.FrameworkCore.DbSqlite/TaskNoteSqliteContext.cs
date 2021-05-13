using Microsoft.EntityFrameworkCore;
using System.IO;

namespace TaskNote.Entity.FrameworkCore.DbSqlite
{
    public class TaskNoteSqliteContext : TaskNoteDbContext
    {
        private readonly IFileInfoFacade _fileInfoFacade; // ここライブラリに置き換えられるかも

        public TaskNoteSqliteContext(IFileInfoFacade fileInfoFacade, DbContextOptions options) : base(options)
        {
            _fileInfoFacade = fileInfoFacade ?? throw new System.ArgumentNullException(nameof(fileInfoFacade));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={Path.Combine(_fileInfoFacade.ApplicationLocation, _fileInfoFacade.Database)}");
            optionsBuilder.UseLazyLoadingProxies(); // 遅延読み込み。WPFアプリで必要
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
