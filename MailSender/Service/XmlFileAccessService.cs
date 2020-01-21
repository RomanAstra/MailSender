using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Xml.Serialization;

namespace MailSender.Service
{
    public sealed class XmlFileAccessService : IDataAccessService
	{
		public ObservableCollection<Emails> GetEmails()
        {
            throw new
                NotImplementedException();
        }

        public int CreateEmail(Emails email)
        {
            throw new
                NotImplementedException();
        }
        private readonly string _path;
        private readonly XmlSerializer _xmlSerializer;

        public XmlFileAccessService()
        {
            _xmlSerializer = new XmlSerializer(typeof(Emails[]));
            _path = Path.Combine("Data.bat");
        }

        public void Save(Emails[] values)
        {
            if (values?.Length <= 0) return;
            using (var fs = new FileStream(_path, FileMode.Create))
            {
                _xmlSerializer.Serialize(fs, values ?? throw new ArgumentNullException(nameof(values)));
            }
        }

        public Emails[] Load()
        {
            Emails[] result;
            if (!File.Exists(_path)) return default(Emails[]);
            using (var fs = new FileStream(_path, FileMode.Open))
            {
                result = (Emails[])_xmlSerializer.Deserialize(fs);
            }
            return result;
        }
    }
}