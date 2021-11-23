using System.Collections.Generic;
using System.Threading.Tasks;
using TaskNote.Entity;

namespace TaskNote.Entity.Sessions
{
    public interface IUserSession
    {
        Task<UserModel> GetById(int id);

        Task<IList<UserModel>> GetAll();

        Task<bool> Post(UserModel input);
    }
}
