using System;

namespace TaskNote.Models.VerificationModels
{
    public abstract class BaseVerificationModel
    {
        public abstract string Text { get; }
    }

    public class VerificationSuccessModel : BaseVerificationModel
    {
        public override string Text => "認証に成功しました。";
    }

    public class VerificationNetworkModel : BaseVerificationModel
    {
        public override string Text => "認証に失敗しました。通信環境を確認してください、";
    }

    public class VerificationErrorModel : BaseVerificationModel
    {
        public string _text;

        public override string Text => _text;

        public VerificationErrorModel(string text)
        {
            _text = text ?? throw new ArgumentNullException(nameof(text));
        }
    }
}
