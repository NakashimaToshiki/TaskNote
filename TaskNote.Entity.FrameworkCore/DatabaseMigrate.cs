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

        public DatabaseMigrate(TDbContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public void Migrate()
        {
            try
            {
                _db.Database.Migrate();
            }
            catch (Exception e)
            {
                throw new DatabaseException("マイグレーションエラー", e);
            }
        }
    }
}
