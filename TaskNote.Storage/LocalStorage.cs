using System;
using System.IO;

namespace TaskNote.Storage
{

    public class LocalStorage
    {
        private readonly IFileInfoFacade _fileInfoFacade;

        public LocalStorage(IFileInfoFacade fileInfoFacade)
        {
            _fileInfoFacade = fileInfoFacade ?? throw new ArgumentNullException(nameof(fileInfoFacade));
        }

        /// <summary>
        /// アプリケーションフォルダを削除。中にあるファイルやフォルダも削除されます。
        /// </summary>
        public void DeleteApplicationDirectory()
        {
            try
            {

                // アプリケーションフォルダを全削除
                DeleteAllFilesInDirectory(_fileInfoFacade.GetApplicationDirectoryInfo().FullName);
            }
            catch (Exception e)
            {
                throw new StorageException(e);
            }
        }

        /// <summary>
        /// 再帰的にディレクトリ内のファイルをすべて削除する。
        /// </summary>
        private void DeleteAllFilesInDirectory(string targetPath)
        {
            if (!Directory.Exists(targetPath)) return;

            // ファイルを削除
            foreach (var path in Directory.GetFiles(targetPath))
            {
                File.SetAttributes(path, FileAttributes.Normal);
                File.Delete(path);
            }

            // フォルダ内のフォルダを再帰的に削除
            foreach (var path in Directory.GetDirectories(targetPath))
            {
                DeleteAllFilesInDirectory(path);
            }
        }
    }
}
