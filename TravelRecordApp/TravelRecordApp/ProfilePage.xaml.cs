using TravelRecordApp.ViewModels;
using Xamarin.Forms;

namespace TravelRecordApp
{
    public partial class ProfilePage : ContentPage
    {
        private readonly ProfileViewModel viewModel;

        public ProfilePage()
        {
            InitializeComponent();

            viewModel = Resources["viewModel"] as ProfileViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            viewModel.GetCategories();
        }
    }
}
