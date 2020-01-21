using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Ioc;
using MailSender.ViewModel;

namespace MailSender
{
	public partial class MainWindow : Window
	{
		private EmailSendService _emailSender;

		public MainWindow()
		{
			InitializeComponent();
		}

		private void TabSwitcherControl_OnBack(object sender, RoutedEventArgs e)
		{
			if (MainTabControl.SelectedIndex == 0) return;
			MainTabControl.SelectedIndex--;
		}

		private void TabSwitcherControl_OnForward(object sender, RoutedEventArgs e)
		{
			if (MainTabControl.SelectedIndex == MainTabControl.Items.Count - 1) return;
			MainTabControl.SelectedIndex++;
		}

        public void BtnClock_Click(object sender, RoutedEventArgs e)
        {
            MainTabControl.SelectedItem = tabPlanner;
        }
    }
}
