using System.Collections.ObjectModel;
using SQLite;
using TravelRecordApp.Model;

namespace TravelRecordApp.ViewModels
{
    public class HistoryViewModel
    {
        private Post selectedPost;

        public ObservableCollection<Post> Posts { get; set; }

        public Post SelectedPost
        {
            get
            {
                return selectedPost;
            }
            set
            {
                selectedPost = value;

                if (selectedPost != null)
                {
                    var postDetailPage = new PostDetailPage(selectedPost);
                    App.Current.MainPage.Navigation.PushAsync(postDetailPage);
                }
            }
        }

        public HistoryViewModel()
        {
            Posts = new ObservableCollection<Post>();
        }

        public void GetPosts()
        {
            Posts.Clear();

            using (var conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();

                var posts = conn
                    .Table<Post>()
                    .Where(p => p.UserId == App.User.Id)
                    .ToList();

                foreach (var post in posts)
                {
                    Posts.Add(post);
                }
            }
        }
    }
}
