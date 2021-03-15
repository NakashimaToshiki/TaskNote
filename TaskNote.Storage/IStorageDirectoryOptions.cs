namespace TaskNote.Storage
{
    public interface IStorageDirectoryOptions
    {
        /// <summary>
        /// インストールローカルディレクトリ
        /// </summary>
        string InstalledLocation { get; }

        /// <summary>
        /// アプリケーションディレクトリ
        /// </summary>
        string ApplicationPath { get; }
    }
}
