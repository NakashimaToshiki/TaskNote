using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace TaskNote
{
    /// <summary>
    /// <see cref="TaskNote"/>名前空間の<see cref="Exception"/>基底クラスとして機能します。
    /// </summary>
    [Serializable()]
    public class TaskNoteException : Exception
    {

        public TaskNoteException()
        {
        }

        public TaskNoteException(string message) : base(message)
        {
        }

        public TaskNoteException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public TaskNoteException(Exception innerException,
            [CallerFilePath] string filePath = "",
            [CallerMemberName] string memberName = "") :
            base($"{System.IO.Path.GetFileNameWithoutExtension(filePath)}.{memberName}", innerException)
        {
        }

        protected TaskNoteException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

    }
}
