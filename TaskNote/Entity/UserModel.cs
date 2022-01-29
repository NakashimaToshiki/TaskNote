using System;
using System.ComponentModel.DataAnnotations;

namespace TaskNote.Entity
{
    public class UserModel : IDataClass
    {
        [Display(Name = "ユーザーID")]
        [Required(ErrorMessage = "入力必須です。")]
        public string Id { get; set; } = string.Empty;

        [Display(Name = "ユーザー名")]
        [Required(ErrorMessage = "入力必須です。")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "パスワード")]
        [Required(ErrorMessage = "入力必須です。")]
        public string Password { get; set; } = string.Empty;

        [Display(Name = "性別")]
        public Sex SexId { get; set; }

        public override string ToString() => this.ToStringProperties();
    }

    public class NullUserModel : UserModel
    {
        public static NullUserModel Instance = new NullUserModel();
    }
}
