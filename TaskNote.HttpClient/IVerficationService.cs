using System.Threading.Tasks;

namespace TaskNote.HttpClient
{
    /// <summary>
    /// ユーザー認証するメソッドを定義します、
    /// </summary>
    public interface IVerficationService
    {
        /// <summary>
        /// ユーザー認証
        /// </summary>
        /// <returns></returns>
        ValueTask<int> GetAuthentication();
    }
}
