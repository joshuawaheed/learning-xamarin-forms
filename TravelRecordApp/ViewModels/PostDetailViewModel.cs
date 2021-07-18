using SQLite;
using TravelRecordApp.Model;
using Xamarin.Forms;

namespace TravelRecordApp.ViewModels
{
    public class PostDetailViewModel
    {
        public Command DeleteCommand { get; set; }
        public Command UpdateCommand { get; set; }
        public Post SelectedPost { get; set; }

        public PostDetailViewModel()
        {
            DeleteCommand = new Command(Delete);
            UpdateCommand = new Command<string>(Update, CanUpdate);
        }

        private bool CanUpdate(string newExperience)
        {
            if (string.IsNullOrWhiteSpace(newExperience))
            {
                return false;
            }

            return true;
        }

        private void Delete()
        {
            using (var conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                var rows = conn.Delete(SelectedPost);

                if (rows > 0)
                {
                    App.Current.MainPage.DisplayAlert(
                        "Success",
                        "Experience successfully deleted",
                        "Ok");
                }
                else
                {
                    App.Current.MainPage.DisplayAlert(
                        "Failure",
                        "Experience failed to be deleted",
                        "Ok");
                }
            }
        }

        private void Update(string newExperience)
        {
            SelectedPost.Experience = newExperience;

            using (var conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                int rows = conn.Update(SelectedPost);

                if (rows > 0)
                {
                    App.Current.MainPage.DisplayAlert(
                        "Success",
                        "Experience successfully updated",
                        "Ok");
                }
                else
                {
                    App.Current.MainPage.DisplayAlert(
                        "Failure",
                        "Experience failed to be updated",
                        "Ok");
                }
            }
        }
    }
}
