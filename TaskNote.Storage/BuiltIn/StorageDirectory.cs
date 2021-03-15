using System;
using System.IO;

namespace TaskNote.Storage.BuiltIn
{
    public class StorageDirectory : IStorageDirectory
    {
        private readonly IStorageDirectoryOptions _options;

        public StorageDirectory(IStorageDirectoryOptions options)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
        }

        public void Initialization()
        {
            try
            {
                Directory.CreateDirectory(_options.ApplicationPath);
            }
            catch (Exception e)
            {
                throw new StorageException(e);
            }
        }
    }
}
