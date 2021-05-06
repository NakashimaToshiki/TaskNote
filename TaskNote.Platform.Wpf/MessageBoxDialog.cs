using System.Windows;

namespace TaskNote.Platform.Wpf
{
    public class MessageBoxDialog : IMessageBox
    {
        public void Show(string text, string caption)
        {
            MessageBox.Show(text, caption);
        }
    }
}
