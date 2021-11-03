using System.Threading.Tasks;

namespace TaskNote.BackEnd.Entity.Users
{
    public interface IUserSession
    {
        ValueTask<UserEntity> GetById(int id);
    }
}
