namespace TaskNote.Entity.FrameworkCore.DbSqlite
{
    public class SqliteDatabaseOptions : IDatabaseOptions
    {
        public string DatabaseFilePath => "database.db";
    }
}
