namespace TaskNote.Database
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
        public DatabaseOptions()
        {

        }
        public string DatabaseFilePath { get; set; }
    }
}
