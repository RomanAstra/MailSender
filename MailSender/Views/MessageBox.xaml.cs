using System.Windows;

namespace MailSender.Views
{
    public partial class MessageBox : Window
    {
        public MessageBox(string mess)
        {
            InitializeComponent();

            MainLabel.Content = mess;
        }

        private void Button_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
