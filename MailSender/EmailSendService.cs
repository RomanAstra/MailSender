using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Windows;

namespace MailSender
{
	public sealed class EmailSendService
	{
		private readonly string _senderAddress;
		private readonly string _password;
		private readonly string _server;
		private readonly int _port;

		private string Subject { get; set; }
		private string Body { get; set; }

		public EmailSendService(string senderAddress, string password, string server, int port)
		{
			_senderAddress = senderAddress;
			_password = password;
			_server = server;
			_port = port;

        }

        public void SendMails(IEnumerable<Emails> emails)
        {
            //foreach (var email in emails) SendMail(email.Email);

            emails.AsParallel()
                .WithDegreeOfParallelism(Environment.ProcessorCount)
                .ForAll(email => SendMail(email.Email));

        }

        public async void SendMailsAsync(IEnumerable<Emails> emails)
        {
            await Task.Yield();
            await Task.WhenAll(emails.Select(email => SendMailAsyncAsync(email.Email))).ConfigureAwait(false);
        }

        private void SendMail(string destinationAddress)
		{
			var message = GetMailMessage(destinationAddress);
			var client = GetSmtpClient();
			try
			{
				client.Send(message);
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка отправки сообщения: {ex}");
			}
			finally
			{
				client.Dispose();
				message.Dispose();
			}
		}

		private async Task SendMailAsyncAsync(string destinationAddress)
		{
			var message = GetMailMessage(destinationAddress);
			var client = GetSmtpClient();
			try
			{
				await client.SendMailAsync(message);
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка отправки сообщения: {ex}");
			}
			finally
			{
				client.Dispose();
				message.Dispose();
			}
		}

		private MailMessage GetMailMessage(string destinationAddress)
		{
			var msg = new MailMessage(_senderAddress, destinationAddress)
			{
				Subject = Subject,
				Body = Body,
				IsBodyHtml = false
			};
			return msg;
		}

		private SmtpClient GetSmtpClient()
		{
			var client = new SmtpClient(_server, _port)
			{
				EnableSsl = true,
				Credentials = new NetworkCredential(_senderAddress, _password)
			};
			return client;
		}
	}
}