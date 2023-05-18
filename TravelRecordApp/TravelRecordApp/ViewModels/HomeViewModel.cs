using TravelRecordApp.Commands;

namespace TravelRecordApp.ViewModels
{
    public class HomeViewModel
    {
        public NewTravelCommand NewTravelCommand { get; set; }

        public HomeViewModel()
        {
            NewTravelCommand = new NewTravelCommand(this);
        }

        public void NewTravelNavigation()
        {
            App.Current.MainPage.Navigation.PushAsync(new NewTravelPage());
        }
    }
}
