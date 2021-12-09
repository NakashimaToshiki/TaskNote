using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskNote.Entity.Sessions
{
    public interface IUserSession
    {
        Task<UserEntity> GetByIdAsync(int id);

        Task<IList<UserEntity>> GetAllAsync();

        Task<bool> DeleteByIdAsync(int id);

        Task<bool> PostAsync(UserEntity input);
    }
}
