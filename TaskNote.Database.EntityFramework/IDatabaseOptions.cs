namespace TaskNote.Database.EntityFramework
{
    /// <summary>
    /// ローカルストレージのファイルパスを取得するプロパティを定義します。
    /// </summary>
    public interface IDatabaseOptions
    {
        string DatabaseFilePath { get; }
    }

    public class DatabaseOptions : IDatabaseOptions
    {
        public string DatabaseFilePath { get; set; }
    }
}
