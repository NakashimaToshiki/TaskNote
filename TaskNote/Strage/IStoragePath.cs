using System;

namespace TaskNote.Strage
{
    /// <summary>
    /// ローカルストレージのファイルパスを取得するプロパティを定義します。
    /// </summary>
    public interface IStoragePath
    {
        string DatabaseFilePath { get; }
    }

    public class StoragePath : IStoragePath
    {
        public string DatabaseFilePath => "database.db";
    }


    // 今のところ不要
    /*
    public static class StoragePathExtentions
    {
        public static void CreateDirectory(this IStoragePath _)
        {
            try
            {
                Directory.CreateDirectory(_.DatabaseFilePath);
            }
            catch (Exception e)
            {
                throw new StorageException(e);
            }
        }
    }*/
}
