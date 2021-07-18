using Plugin.Geolocator;
using TravelRecordApp.ViewModels;
using Xamarin.Forms;

namespace TravelRecordApp
{
    public partial class NewTravelPage : ContentPage
    {
        private readonly NewTravelViewModel viewModel;

        public NewTravelPage()
        {
            InitializeComponent();

            viewModel = Resources["viewModel"] as NewTravelViewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var locator = CrossGeolocator.Current;
            var position = await locator.GetPositionAsync();

            viewModel.GetVenues(position.Latitude, position.Longitude);
        }
    }
}
