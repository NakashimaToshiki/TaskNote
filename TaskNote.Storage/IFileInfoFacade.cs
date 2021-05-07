namespace TaskNote.Storage
{
    public interface IFileInfoFacade
    {
        /// <summary>
        /// インストールローカルディレクトリ
        /// </summary>
        string InstalledLocation { get; }

        /// <summary>
        /// アプリケーションディレクトリ
        /// </summary>
        string ApplicationPath { get; }

        string Database { get; }

        string NLog { get; }

        string AppSetting { get; }

        string TraceLogFolder { get; }
    }
}
