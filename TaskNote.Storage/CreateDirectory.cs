using System;
using System.IO;

namespace TaskNote.Storage
{
    public class CreateDirectory
    {
        private readonly IFileInfoFacade _fileInfoFacade;

        public CreateDirectory(IFileInfoFacade fileInfoFacade)
        {
            _fileInfoFacade = fileInfoFacade ?? throw new ArgumentNullException(nameof(fileInfoFacade));
        }

        public void Create()
        {
            try
            {
                Directory.CreateDirectory(_fileInfoFacade.ApplicationLocation);
            }
            catch (Exception e)
            {
                throw new StorageException(e);
            }
        }
    }
}
