using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Data;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MailSender.Service;
using MailSender.Views;

namespace MailSender.ViewModel
{
	public sealed class MainWindowViewModel : ViewModelBase
	{
		#region Private Variables

		private readonly IDataAccessService _dataService;
		private ObservableCollection<Emails> _emails = new ObservableCollection<Emails>();
		private Emails _currentEmail = new Emails();
		private SmtpServerInfo _selectedServer;
		private KeyValuePair<string, string> _curSenders;
		private string _filterName;
		private CollectionViewSource _emailsView;
		private readonly ObservableCollection<SmtpServerInfo> _smtpServers = new ObservableCollection<SmtpServerInfo>(new[]
		{
			new SmtpServerInfo { Server = "smtp.mail.ru", Port = 00 },
			new SmtpServerInfo { Server = "smtp.rambler.ru", Port = 00 },
			new SmtpServerInfo { Server = "smtp.google.ru", Port = 00 },
		});
        public ObservableCollection<ListViewItemScheduler> SendMails { get; set; }

        #endregion

        public MainWindowViewModel(IDataAccessService dataService)
		{
			_dataService = dataService;

			ReadAllMailsCommand = new RelayCommand(GetEmails);
			SaveMailCommand = new RelayCommand<Emails>(SaveEmail);
			DeleteServerCommand = new RelayCommand<SmtpServerInfo>(OnDeleteServerCommandExecuted);
            SendMails = new ObservableCollection<ListViewItemScheduler>();
            BtnAddMail = new RelayCommand<ObservableCollection<ListViewItemScheduler>>(AddMail);
        }

		#region Properties

		public IEnumerable<SmtpServerInfo> SmtpServers => _smtpServers;

		public SmtpServerInfo SelectedServer
		{
			get => _selectedServer;
			set => Set(ref _selectedServer, value);
		}

		public KeyValuePair<string, string> CurSenders
		{
			get => _curSenders;
			set => Set(ref _curSenders, value);
		}

		public ObservableCollection<Emails> Emails
		{
			get => _emails;
			set
			{
				if (!Set(ref _emails, value)) return;
				_emailsView = new CollectionViewSource { Source = value };
				_emailsView.Filter += OnEmailsCollectionViewSourceFilter;
				RaisePropertyChanged(nameof(EmailsView));
			}
		}

		public string FilterName
		{
			get => _filterName;
			set
			{
				if (!Set(ref _filterName, value)) return;
				EmailsView.Refresh();
			}
		}

		public ICollectionView EmailsView => _emailsView?.View;

		public Emails CurrentEmail
		{
			get => _currentEmail;
			set => Set(ref _currentEmail, value);
		}

		#endregion

		#region Commands

		public RelayCommand ReadAllMailsCommand { get; }
		public RelayCommand<Emails> SaveMailCommand { get; }
		public RelayCommand<SmtpServerInfo> DeleteServerCommand { get; }
        public RelayCommand<ObservableCollection<ListViewItemScheduler>> BtnAddMail { get; set; }

        #endregion

        #region Private Methods

        private void OnEmailsCollectionViewSourceFilter(object sender, FilterEventArgs e)
		{
			if (!(e.Item is Emails email) || string.IsNullOrWhiteSpace(_filterName)) return;
			if (!email.Name.Contains(_filterName))
				e.Accepted = false;
		}

		private void OnDeleteServerCommandExecuted(SmtpServerInfo serverInfo) => _smtpServers.Remove(serverInfo ?? SelectedServer);

		private void SaveEmail(Emails email)
		{
			email.Id = _dataService.CreateEmail(email);
			if (email.Id == 0) return;
			Emails.Add(email);
		}

		private void GetEmails() => Emails = _dataService.GetEmails();

        private void AddMail(ObservableCollection<ListViewItemScheduler> obj = null)
        {
            SendMails.Add(new ListViewItemScheduler(SendMails));
        }

        #endregion
    }
}
