using TravelRecordApp.ViewModels;
using Xamarin.Forms;

namespace TravelRecordApp
{
    public partial class HistoryPage : ContentPage
    {
        private readonly HistoryViewModel viewModel;

        public HistoryPage()
        {
            InitializeComponent();

            viewModel = Resources["viewModel"] as HistoryViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            viewModel.GetPosts();
        }
    }
}
