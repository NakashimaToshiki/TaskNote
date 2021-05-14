using Microsoft.EntityFrameworkCore;

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
            optionsBuilder.UseSqlite($"Data Source={_fileInfoFacade.GetDatabaseFileInfo().FullName}");
            optionsBuilder.UseLazyLoadingProxies(); // 遅延読み込み。WPFアプリで必要
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
