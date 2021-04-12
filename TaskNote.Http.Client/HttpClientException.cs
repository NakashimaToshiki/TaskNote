using System;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using TaskNote.Abstracts;

namespace TaskNote.Http.Client
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

    public class HttpRequestException : HttpClientException
    {
        public HttpRequestException(string message, HttpStatusCode statusCode) : base(message)
        {

        }

        public override string Message => $"{base.Message} {StatusCode} {(int)StatusCode}";

        public HttpStatusCode StatusCode { get; }
    }
}
