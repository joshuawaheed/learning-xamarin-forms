using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using SQLite;
using TravelRecordApp.Model;
using Xamarin.Forms;

namespace TravelRecordApp.ViewModels
{
    public class NewTravelViewModel : INotifyPropertyChanged
    {
        private string experience;
        private bool postIsReady;
        private Venue selectedVenue;

        public string Experience
        {
            get
            {
                return experience;
            }
            set
            {
                experience = value;
                OnPropertyChanged(nameof(Experience));
                OnPropertyChanged(nameof(PostIsReady));
            }
        }

        public bool PostIsReady
        {
            get
            {
                return
                    !string.IsNullOrWhiteSpace(Experience) &&
                    SelectedVenue != null;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Command SaveCommand { get; set; }

        public Venue SelectedVenue
        {
            get {
                return selectedVenue;
            }
            set
            {
                selectedVenue = value;
                OnPropertyChanged(nameof(PostIsReady));
            }
        }

        public ObservableCollection<Venue> Venues { get; set; }

        public NewTravelViewModel()
        {
            SaveCommand = new Command<bool>(Save, CanSave);
            Venues = new ObservableCollection<Venue>();
        }

        public async void GetVenues(double latitude, double longitude)
        {
            var venues = await Venue.GetVenues(latitude, longitude);

            Venues.Clear();

            foreach (var venue in venues)
            {
                Venues.Add(venue);
            }
        }

        private bool CanSave(bool parameter)
        {
            return parameter;
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Save(bool parameter)
        {
            try
            {
                var firstCategory = SelectedVenue.Categories.FirstOrDefault();

                var post = new Post()
                {
                    Address = SelectedVenue.Location.Address,
                    CategoryId = firstCategory.Id,
                    CategoryName = firstCategory.Name,
                    Distance = SelectedVenue.Location.Distance,
                    Experience = Experience,
                    Latitude = SelectedVenue.Location.Lat,
                    Longitude = SelectedVenue.Location.Lng,
                    UserId = App.User.Id,
                    VenueName = SelectedVenue.Name
                };

                using (var conn = new SQLiteConnection(App.DatabaseLocation))
                {

                    conn.CreateTable<Post>();

                    int rows = conn.Insert(post);

                    if (rows > 0)
                    {
                        Experience = string.Empty;

                        App.Current.MainPage.DisplayAlert(
                            "Success",
                            "Experience successfully inserted",
                            "Ok");
                    }
                    else
                    {
                        App.Current.MainPage.DisplayAlert(
                            "Failure",
                            "Experience failed to be inserted",
                            "Ok");
                    }
                }
            }
            catch (NullReferenceException)
            {
            }
            catch (Exception)
            {
            }
        }
    }
}
