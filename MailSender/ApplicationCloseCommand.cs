using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;

namespace MailSender
{
	public sealed class ApplicationCloseCommand : MarkupExtension, ICommand
	{
		public override object ProvideValue(IServiceProvider serviceProvider) => this;
		private event EventHandler _canExecuteChanged;
		public event EventHandler CanExecuteChanged
		{
			add
			{
				_canExecuteChanged += value;
				CommandManager.RequerySuggested += value;
			}
			remove
			{
				_canExecuteChanged -= value;
				CommandManager.RequerySuggested -= value;
			}
		}
		public void Execute(object parameter) => Application.Current.Shutdown();
		public bool CanExecute(object parameter) => true;
	}
}