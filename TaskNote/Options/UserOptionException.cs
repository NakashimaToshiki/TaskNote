using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace TaskNote.Options
{
    [Serializable()]
    public class UserOptionException : TaskNoteException
    {
        public UserOptionException()
        {
        }

        public UserOptionException(string message) : base(message)
        {
        }

        public UserOptionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public UserOptionException(Exception innerException, [CallerFilePath] string filePath = "", [CallerMemberName] string memberName = "") : base(innerException, filePath, memberName)
        {
        }

        protected UserOptionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
