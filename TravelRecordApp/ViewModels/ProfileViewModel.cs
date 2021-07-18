using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using SQLite;
using TravelRecordApp.Model;

namespace TravelRecordApp.ViewModels
{
    public class ProfileViewModel : INotifyPropertyChanged
    {
        private int postsCount;

        public ObservableCollection<CategoryCount> Categories { get; set; }

        public int PostsCount
        {
            get
            {
                return postsCount;
            }
            set
            {
                postsCount = value;
                OnPropertyChanged(nameof(PostsCount));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ProfileViewModel()
        {
            Categories = new ObservableCollection<CategoryCount>();
        }

        public void GetCategories()
        {
            Categories.Clear();

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

                foreach (var category in categories)
                {
                    var count = posts
                        .Where(p => p.CategoryName == category)
                        .ToList()
                        .Count;

                    Categories.Add(new CategoryCount
                    {
                        Name = category,
                        Count = count
                    });
                }

                PostsCount = posts.Count();
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
