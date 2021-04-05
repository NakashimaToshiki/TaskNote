using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace TaskNote.Platform
{
    public class UserInfoDialogViewModel : BindableBase
    {
        private string _userId;
        
        [Required(ErrorMessage="ユーザーネームを入力して下さい。")]
        public string UserId
        {
            get => _userId;
            set { SetProperty(ref _userId, value); }
        }

        private string _password;
        private readonly UserOptions _options;

        [Required(ErrorMessage = "パスワードを入力して下さい。")]
        public string Password
        {
            get => _password;
            set { SetProperty(ref _password, value); }
        }

        public UserInfoDialogViewModel(UserOptions options)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
        }


    }
}
