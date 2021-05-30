using System;
using System.Collections.Generic;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using SQLite;
using TravelRecordApp.Model;
using Xamarin.Forms;

namespace TravelRecordApp
{
    public partial class MapPage : ContentPage
    {
        private bool hasLocationPermission = false;

        public MapPage()
        {
            InitializeComponent();
            GetPermissions();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (hasLocationPermission)
            {
                var locator = CrossGeolocator.Current;
                locator.PositionChanged += Locator_PositionChanged;
                await locator.StartListeningAsync(TimeSpan.Zero, 100);
            }

            GetLocation();

            using (var conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                var posts = conn.Table<Post>().ToList();
                DisplayInMap(posts);
            }
        }

        protected override async void OnDisappearing()
        {
            base.OnDisappearing();
            await CrossGeolocator.Current.StopListeningAsync();
            CrossGeolocator.Current.PositionChanged -= Locator_PositionChanged;
        }

        private void DisplayInMap(List<Post> posts)
        {
            foreach (var post in posts)
            {
                try
                {
                    var position = new Xamarin.Forms.Maps.Position(
                        post.Latitude,
                        post.Longitude
                    );

                    var pin = new Xamarin.Forms.Maps.Pin
                    {
                        Address = post.Address,
                        Label = post.VenueName,
                        Position = position,
                        Type = Xamarin.Forms.Maps.PinType.SavedPin
                    };

                    locationsMap.Pins.Add(pin);
                }
                catch (NullReferenceException nre)
                {

                }
                catch (Exception ex)
                {

                }
            }
        }

        private async void GetLocation()
        {
            if (hasLocationPermission)
            {
                var locator = CrossGeolocator.Current;
                var position = await locator.GetPositionAsync();
                MoveMap(position);
            }
        }

        private async void GetPermissions()
        {
            try
            {
                var currentCrossPermission = CrossPermissions.Current;
                var permission = Permission.LocationWhenInUse;
                var status = await currentCrossPermission.CheckPermissionStatusAsync(permission);

                if (status != PermissionStatus.Granted)
                {
                    if (await currentCrossPermission.ShouldShowRequestPermissionRationaleAsync(permission))
                    {
                        await DisplayAlert(
                            "Need your location",
                            "We need access to your location",
                            "Ok");
                    }

                    var results = await currentCrossPermission.RequestPermissionsAsync(permission);

                    if (results.ContainsKey(permission))
                    {
                        status = results[permission];
                    }
                }

                if (status == PermissionStatus.Granted)
                {
                    hasLocationPermission = true;
                    locationsMap.IsShowingUser = true;
                    GetLocation();
                }
                else
                {
                    await DisplayAlert(
                        "Location denied",
                        "Your didn't give us permission to access your location, " +
                        "so we can't show you the map",
                        "Ok");
                }
            }
            catch (Exception e)
            {
                await DisplayAlert("Error", e.Message, "Ok");
            }
        }

        private void Locator_PositionChanged(object sender, PositionEventArgs e)
        {
            MoveMap(e.Position);
        }

        private void MoveMap(Position position)
        {
            var center = new Xamarin.Forms.Maps.Position(
                position.Latitude,
                position.Longitude
            );

            var span = new Xamarin.Forms.Maps.MapSpan(center, 1, 1);

            locationsMap.MoveToRegion(span);
        }
    }
}
