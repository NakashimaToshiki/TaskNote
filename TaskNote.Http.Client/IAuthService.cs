using System.Threading.Tasks;

namespace TaskNote.Http.Client
{
    /// <summary>
    /// ユーザー認証するメソッドを定義します、
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// ユーザー認証
        /// </summary>
        /// <returns></returns>
        ValueTask<bool> GetAuthentication();
    }
}
