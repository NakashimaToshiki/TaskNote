using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using TaskNote.Abstracts;

namespace TaskNote.HttpClient
{
    [Serializable()]
    public class HttpClientException : TaskNoteException
    {
        public HttpClientException()
        {
        }

        public HttpClientException(string message) : base(message)
        {
        }

        public HttpClientException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public HttpClientException(Exception innerException, [CallerFilePath] string filePath = "", [CallerMemberName] string memberName = "") : base(innerException, filePath, memberName)
        {
        }

        protected HttpClientException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
