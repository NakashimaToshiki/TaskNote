using System.Threading.Tasks;

namespace TaskNote.Server.Entity.Users
{
    public interface IUserSession
    {
        ValueTask<UserEntity> GetById(int id);
    }
}
