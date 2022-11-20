using Xamarin.Forms;

namespace FinanceApp.Views
{
    public partial class MainPage : ContentPage
	{	
		public MainPage()
		{
			InitializeComponent();
			Xamarin.Forms.PlatformConfiguration.iOSSpecific.Page.SetUseSafeArea(this, true);
		}
	}
}

