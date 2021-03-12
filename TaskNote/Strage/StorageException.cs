using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using TaskNote.Abstracts;

namespace TaskNote.Strage
{
    [Serializable()]
    public class StorageException : TaskNoteException
    {
        public StorageException()
        {
        }

        public StorageException(string message) : base(message)
        {
        }

        public StorageException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public StorageException(Exception innerException, [CallerFilePath] string filePath = "", [CallerMemberName] string memberName = "") : base(innerException, filePath, memberName)
        {
        }

        protected StorageException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
