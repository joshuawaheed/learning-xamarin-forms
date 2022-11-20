using FinanceApp.Models;
using Xamarin.Forms;

namespace FinanceApp.Views
{
    public partial class PostPage : ContentPage
	{	
		public PostPage()
		{
			InitializeComponent();
			Xamarin.Forms.PlatformConfiguration.iOSSpecific.Page.SetUseSafeArea(this, true);
		}

		public PostPage(Item item)
		{
			InitializeComponent();
			Xamarin.Forms.PlatformConfiguration.iOSSpecific.Page.SetUseSafeArea(this, true);
			webView.Source = item.ItemLink;
		}
	}
}

