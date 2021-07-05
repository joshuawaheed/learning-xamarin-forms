using System;
using System.Collections.Generic;
using System.Linq;
using Plugin.Geolocator;
using SQLite;
using TravelRecordApp.Logic;
using TravelRecordApp.Model;
using Xamarin.Forms;

namespace TravelRecordApp
{
    public partial class NewTravelPage : ContentPage
    {
        public NewTravelPage()
        {
            InitializeComponent();
        }

        public void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            try
            {
                var selectedVenue = venueListView.SelectedItem as Venue;
                var firstCategory = selectedVenue.Categories.FirstOrDefault();

                Post post = new Post()
                {
                    Address = selectedVenue.Location.Address,
                    CategoryId = firstCategory.Id,
                    CategoryName = firstCategory.Name,
                    Distance = selectedVenue.Location.Distance,
                    Experience = experienceEntry.Text,
                    Latitude = selectedVenue.Location.Lat,
                    Longitude = selectedVenue.Location.Lng,
                    UserId = App.User.Id,
                    VenueName = selectedVenue.Name
                };

                using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                {

                    conn.CreateTable<Post>();

                    int rows = conn.Insert(post);

                    if (rows > 0)
                    {
                        DisplayAlert("Success", "Experience successfully inserted", "Ok");
                    }
                    else
                    {
                        DisplayAlert("Failure", "Experience failed to be inserted", "Ok");
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

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var locator = CrossGeolocator.Current;
            var position = await locator.GetPositionAsync();

            var venues = await VenueLogic.GetVenues(
                position.Latitude,
                position.Longitude);

            venueListView.ItemsSource = venues;
        }
    }
}
