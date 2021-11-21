using System;
using System.Runtime.CompilerServices;

namespace TaskNote.BackEnd.Entity
{
    [Serializable()]
    public class DatabaseException : TaskNoteException
    {
        public DatabaseException()
        {
        }

        public DatabaseException(string message) : base(message)
        {
        }

        public DatabaseException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public DatabaseException(Exception innerException, [CallerFilePath] string filePath = "", [CallerMemberName] string memberName = "") : base(innerException, filePath, memberName)
        {
        }
    }
}
