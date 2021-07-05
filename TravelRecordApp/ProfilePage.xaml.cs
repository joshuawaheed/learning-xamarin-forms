using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using TravelRecordApp.Model;
using Xamarin.Forms;

namespace TravelRecordApp
{
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (var conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();

                var posts = conn
                    .Table<Post>()
                    .Where(p => p.UserId == App.User.Id)
                    .ToList();

                var categories = posts
                    .OrderBy(p => p.CategoryId)
                    .Select(p => p.CategoryName)
                    .Distinct()
                    .ToList();

                var categoriesCount = new Dictionary<string, int>();

                foreach (var category in categories)
                {
                    var count = posts
                        .Where(p => p.CategoryName == category)
                        .ToList()
                        .Count;

                    categoriesCount.Add(category ?? string.Empty, count);
                }

                categoriesListView.ItemsSource = categoriesCount;
                postCountLabel.Text = posts.Count.ToString();
            }
        }
    }
}
