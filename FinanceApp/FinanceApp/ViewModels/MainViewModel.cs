using FinanceApp.Models;
using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Text;
using System.Xml.Serialization;

namespace FinanceApp.ViewModels
{
	public class MainViewModel : INotifyPropertyChanged
	{
		private const string RssFeedAddress = "https://search.cnbc.com/rs/search/combinedcms/view.xml?partnerId=wrss01&id=10000664";

        public Posts Blog { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel()
		{
			ReadRss();
		}

		public void ReadRss()
		{
			XmlSerializer serializer = new XmlSerializer(typeof(Posts));

			using (WebClient client = new WebClient())
			{
				string xml = Encoding.Default.GetString(client.DownloadData(RssFeedAddress));

				using (Stream reader = new MemoryStream(Encoding.UTF8.GetBytes(xml)))
				{
					Blog = (Posts)serializer.Deserialize(reader);
				}
			}
		}

		private void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
    }
}

