using System.Windows;

namespace MailSender
{
    public sealed class DefaultDialogService : IDialogService
    {
        public void ShowMessage(string message)
        {
            var win = Application.Current.MainWindow;
            var dialog = new Views.MessageBox(message)
            {
                Owner = win
            };
            dialog.Show();
        }
    }
}
