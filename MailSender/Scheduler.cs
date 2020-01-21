using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Threading;

namespace MailSender
{
    public sealed class Scheduler
    {
        private DispatcherTimer _timer;
        private EmailSendService _emailSender;
        private IEnumerable<Emails> _listEmails;
        private string _mailSubject;
        private string _mailBody;
        private Dictionary<DateTime, string> _dicDates; 
        public Action<string> MessageAfterOneSend;
        public Action<string> MessageAfterSendAll;

        public Action<string> MessageAfterPlanning;

        public Scheduler(IEnumerable<Emails> emails)
        {
            _timer = new DispatcherTimer();
            _listEmails = emails;
            _dicDates = new Dictionary<DateTime, string>();
        }
        
        public TimeSpan GetSendTime(string strSendTime)
        {
            TimeSpan tsSendTime = new TimeSpan();
            try
            {
                tsSendTime = TimeSpan.Parse(strSendTime);
            }
            catch { }
            return tsSendTime;
        }
        
        public Dictionary<DateTime, string> DatesEmailTexts
        {
            get { return _dicDates; }
            set
            {
                _dicDates = value;
                _dicDates = _dicDates.OrderBy(pair => pair.Key).ToDictionary(pair => pair.Key, pair => pair.Value);
            }
        }

        public void SendMails(EmailSendService emailSender)
        {
            this._emailSender = emailSender;

            _timer.Tick += TimerTick;
            _timer.Interval = new TimeSpan(0, 0, 1);
            _timer.Start();
            MessageAfterPlanning?.Invoke("Отправка писем запланирована");
        }

        private void TimerTick(object sender, EventArgs e)
        {
            if (_dicDates.Count > 0)
            {
                DateTime _nextSend = _dicDates.Keys.First<DateTime>();
                if (_nextSend.ToShortDateString() == DateTime.Now.ToShortDateString() && _nextSend.ToShortTimeString() == DateTime.Now.ToShortTimeString())
                {
                    _mailSubject = $"Рассылка от {_nextSend} ";
                    _mailBody = _dicDates[_dicDates.Keys.First<DateTime>()];
                    _emailSender.SendMails(_listEmails);
                    MessageAfterOneSend?.Invoke($"Письмо от {_nextSend} отправлено");
                    _dicDates.Remove(_dicDates.Keys.First<DateTime>());
                }
            }
            else if (_dicDates.Count == 0)
            {
                _timer.Stop();
                MessageAfterSendAll?.Invoke("Запланированная отправка писем завершена");
            }
        }
    }
}
