using System;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace MailSender
{
	partial class Emails/* : IDataErrorInfo*/
	{
		//public string Error { get; }

		//public string this[string columnName]
		//{
		//	get
		//	{
		//		switch (columnName)
		//		{
		//			case nameof(Email):

		//				Console.WriteLine(1);
		//				var address = Email;
		//				if (string.IsNullOrWhiteSpace(address)) return "������ ������ �����";
		//				if (!Regex.IsMatch(address, @"[a-zA-A]\w*@\w+\.\w+"))
		//					return "������ ������������ �����";
		//				return "";
		//			default: return "";
		//		}
		//	}
		//}

		partial void OnIdChanging(int value)
		{
			if (value < 0)
				throw new ArgumentOutOfRangeException(nameof(value), "�������� ������ ���� ������ ����");
		}
	}
}