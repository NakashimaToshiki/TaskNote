using System.Collections.Generic;

namespace TaskNote.Entity
{
    public class UserModelDammy
    {
        public IList<UserModel> Dammys = new List<UserModel>() {
            new UserModel(){
                Id = "1",
                Name = "user1",
            },
            new UserModel(){
                Id = "2",
                Name = "user2",
            },
            new UserModel(){
                Id = "3",
                Name = "user3",
            }
        };
    }
}
