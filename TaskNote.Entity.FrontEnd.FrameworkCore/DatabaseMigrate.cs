using Microsoft.EntityFrameworkCore;
using System;

namespace TaskNote.Entity.FrameworkCore
{
    /// <summary>
    /// <see cref="Microsoft.EntityFrameworkCore"/>によるマイグレートを実行する<see cref="IMigrate"/>の実装クラスを提供します。
    /// </summary>
    public class DatabaseMigrate<TDbContext> : IMigrate where TDbContext : DbContext
    {
        private readonly TDbContext _db;
        private readonly IFileInfoFacade _fileInfoFacade;

        public DatabaseMigrate(TDbContext db, IFileInfoFacade fileInfoFacade)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _fileInfoFacade = fileInfoFacade ?? throw new ArgumentNullException(nameof(fileInfoFacade));
        }

        public void Migrate()
        {
            try
            {
                _fileInfoFacade.GetDatabaseFileInfo().Directory.Create();
                _db.Database.Migrate();
            }
            catch (Exception e)
            {
                throw new DatabaseException("マイグレーションエラー", e);
            }
        }
    }
}
