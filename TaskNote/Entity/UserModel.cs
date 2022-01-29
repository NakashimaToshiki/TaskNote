using System;
using System.ComponentModel.DataAnnotations;

namespace TaskNote.Entity
{
    public class UserModel : IDataClass
    {
        public string Id { get; set; }

        [Display(Name = "ユーザー名")]
        public string Name { get; set; }

        public override string ToString() => this.ToStringProperties();
    }

    public class NullUserModel : UserModel
    {
        public static NullUserModel Instance = new NullUserModel();
    }
}
