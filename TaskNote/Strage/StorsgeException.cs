using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using TaskNote.Abstracts;

namespace TaskNote.Strage
{
    [Serializable()]
    public class StorsgeException : TaskNoteException
    {
        public StorsgeException()
        {
        }

        public StorsgeException(string message) : base(message)
        {
        }

        public StorsgeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public StorsgeException(Exception innerException, [CallerFilePath] string filePath = "", [CallerMemberName] string memberName = "") : base(innerException, filePath, memberName)
        {
        }

        protected StorsgeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
