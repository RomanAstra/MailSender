using System.Globalization;
using System.Windows.Controls;

namespace MailSender.ValidationRules
{
	public sealed class DatabaseID : ValidationRule
	{
		public override ValidationResult Validate(object value, CultureInfo cultureInfo)
		{
			if (value is string str)
			{
				if (!int.TryParse(str, out var i)) return new ValidationResult(false, "Строка имела неверный формат");

				value = i;
			}

			if (!(value is int id)) return new ValidationResult(false, "Некорректный ввод");

			if (id < 0) return new ValidationResult(false, "Индификатор должен быть больше нуля");
			return ValidationResult.ValidResult;
		}
	}
}