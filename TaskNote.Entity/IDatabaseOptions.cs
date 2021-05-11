using System.Runtime.CompilerServices;

namespace TaskNote.Entity
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
        public DatabaseOptions(
            [CallerFilePath] string filePath = "",
            [CallerMemberName] string memberName = "")
        {
            DatabaseFilePath = $"{filePath}_{memberName}.db";
        }

        public string DatabaseFilePath { get; private set; }
    }
}
