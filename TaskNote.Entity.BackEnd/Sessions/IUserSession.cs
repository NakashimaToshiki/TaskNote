using System.Threading.Tasks;
using TaskNote.Entity;

namespace TaskNote.Entity.Sessions
{
    public interface IUserSession
    {
        Task<UserEntity> GetById(int id);
    }
}
