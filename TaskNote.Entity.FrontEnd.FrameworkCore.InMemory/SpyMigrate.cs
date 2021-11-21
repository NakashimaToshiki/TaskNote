namespace TaskNote.Entity.FrameworkCore.InMemory
{
    /// <summary>
    /// <see cref="Microsoft.EntityFrameworkCore.InMemory"/>用のスパイモック<see cref="IMigrate"/>の実装クラス
    /// </summary>
    public class SpyMigrate : IMigrate
    {
        public int MigrateCount { get; protected set; }
        public void Migrate()
        {
            MigrateCount++;
        }
    }
}
