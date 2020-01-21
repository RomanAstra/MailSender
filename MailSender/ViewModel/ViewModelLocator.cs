using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using MailSender.Service;

namespace MailSender.ViewModel
{
    public sealed class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
			
            SimpleIoc.Default.Register<MainWindowViewModel>();
            SimpleIoc.Default.Register<IDataAccessService, DataBaseAccessService>();
		}

        public MainWindowViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainWindowViewModel>();
            }
        }
    }
}