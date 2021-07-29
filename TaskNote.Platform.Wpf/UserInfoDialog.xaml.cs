using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using TaskNote.Models.VerificationModels;

namespace TaskNote.Platform.Wpf
{
    /// <summary>
    /// UserInfoDialog.xaml の相互作用ロジック
    /// </summary>
    public partial class UserInfoDialog : Window, IUserInfoView
    {
        public UserInfoDialog(UserInfoViewModel viewModel, IMessageBox messageBox)
        {
            InitializeComponent();
            this.DataContext = viewModel ?? throw new ArgumentNullException(nameof(viewModel));

            this._cancelButton.Click += (_, __) =>
            {
                Result = UserInfoDialogResult.Cancel;
                this.Close();
            };
            this._okButton.Click += async (_, __) =>
            {
                var model = await viewModel.CheckVertification();
                if (model is VerificationSuccessModel)
                {
                    Result = UserInfoDialogResult.OK;
                    this.Close();
                    return;
                }

                messageBox.Show(model.Text, "ログイン失敗");
            };
        }

        public UserInfoDialogResult Result { get; private set; } = UserInfoDialogResult.Cancel;

        private void TextBlock_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // 入力値が数値か否か判定し、数値でない場合は処理済みにします。
            var regex = new Regex(UserInfoViewModel.NUMBER_PATTERN);
            e.Handled = !regex.IsMatch(e.Text);
        }

        private void TextBlock_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            // 貼り付けの場合
            if (e.Command == ApplicationCommands.Paste)
            {
                // 入力判定を処理済みにします。
                e.Handled = true;
            }
        }
    }
}
