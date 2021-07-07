using System;
using System.Runtime.CompilerServices;

namespace TaskNote
{
    /// <summary>
    /// <see cref="IDataClass"/>を実装したデータクラスの<see cref="Exception"/>を提供します。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable()]
    public class DataClassException<T> : TaskNoteException where T : IDataClass
    {
        public T Value { get; }

        public override string Message => $"{base.Message} {nameof(T)} = {Value}";

        public DataClassException() : base()
        {
        }

        public DataClassException(string message, T value) : base(message)
        {
            Value = value ?? throw new ArgumentException(nameof(value));
        }

        public DataClassException(string message, Exception innerException, T value) : base(message, innerException)
        {
            Value = value ?? throw new ArgumentException(nameof(value));
        }

        public DataClassException(Exception innerException, T value, [CallerFilePath] string filePath = "", [CallerMemberName] string memberName = "") : base(innerException, filePath, memberName)
        {
            Value = value ?? throw new ArgumentException(nameof(value));
        }
    }
}
