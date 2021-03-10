namespace TaskNote.Database
{
    /// <summary>
    /// データベースのマイグレートを実行するメソッドを提供します。
    /// </summary>
    public interface IMigrate
    {
        void Migrate();
    }
}
