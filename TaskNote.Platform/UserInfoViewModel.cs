using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TaskNote.Models.Repositoris;
using TaskNote.Models.VerificationModels;

namespace TaskNote.Platform
{
    public class UserInfoViewModel : BindableBase
    {
        private string _userId;
        
        [Required(ErrorMessage="ユーザー名を入力して下さい。")]
        [RegularExpression("[a-zA-Z0-9]+", ErrorMessage = "ユーザー名は英数字のみです。")]
        public string UserId
        {
            get => _userId;
            set { SetProperty(ref _userId, value); }
        }

        private string _password;

        [Required(ErrorMessage = "パスワードを入力して下さい。")]
        public string Password
        {
            get => _password;
            set { SetProperty(ref _password, value); }
        }

        private readonly VerficationRepository _repository;
        private readonly UserOptions _options;

        public UserInfoViewModel(VerficationRepository repository, UserOptions options)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _options = options ?? throw new ArgumentNullException(nameof(options));
        }

        public async ValueTask<BaseVerificationModel> CheckVertification()
        {
            try
            {
                var errors = new List<ValidationResult>();
                if(!Validator.TryValidateObject(this, new ValidationContext(this), errors))
                {
                    throw new ValidationException(string.Join("\r\n", errors.Select(_ => _.ErrorMessage)));
                }
                // 必要があればint.Parseもここで呼び出す
                _options.UserId = UserId;
                _options.Password = Password;
            }
            catch (Exception e)
            {
                return new VerificationErrorModel(e.Message);
            }

            return await _repository.Verfication();
        }
    }
}
