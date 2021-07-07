using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace TaskNote.Configuration
{
    public class ConfigurationException : TaskNoteException
    {
        public ConfigurationException()
        {
        }

        public ConfigurationException(string message) : base(message)
        {
        }

        public ConfigurationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public ConfigurationException(Exception innerException, [CallerFilePath] string filePath = "", [CallerMemberName] string memberName = "") : base(innerException, filePath, memberName)
        {
        }

        protected ConfigurationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
