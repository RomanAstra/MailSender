using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace MailSender.Views
{
    /// <summary>
    /// Логика взаимодействия для ListViewItemScheduler.xaml
    /// </summary>
    public partial class ListViewItemScheduler : UserControl, INotifyPropertyChanged
    {
        private DateTime _sendDateTime;
        private ObservableCollection<ListViewItemScheduler> _mailsScheduler;
        public event PropertyChangedEventHandler PropertyChanged;

        public ListViewItemScheduler(ObservableCollection<ListViewItemScheduler> mailsScheduler)
        {
            InitializeComponent();
            _mailsScheduler = mailsScheduler;
            SendDateTime = DateTime.Now;
        }

        public string MailText { get; set; }

        public DateTime SendDateTime
        {
            get { return _sendDateTime; }
            set
            {
                _sendDateTime = value;
                OnPropertyChanged(nameof(SendDateTime));
            }
        }

        private void BtnEditMailText_Click(object sender, RoutedEventArgs e)
        {
            //MailTextWindow mailTextWindow = new MailTextWindow(MailText);
            //mailTextWindow.ShowDialog();
            //if (mailTextWindow.DialogResult == true) MailText = mailTextWindow.MailText;
        }

        private void BtnDelMail_Click(object sender, RoutedEventArgs e)
        {
            _mailsScheduler.Remove(this);
        }

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
