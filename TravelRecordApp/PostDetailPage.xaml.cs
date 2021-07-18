using TravelRecordApp.Model;
using TravelRecordApp.ViewModels;
using Xamarin.Forms;

namespace TravelRecordApp
{
    public partial class PostDetailPage : ContentPage
    {
        public PostDetailPage()
        {

        }

        public PostDetailPage(Post selectedPost)
        {
            InitializeComponent();

            (Resources["viewModel"] as PostDetailViewModel).SelectedPost = selectedPost;
            addressLabel.Text = selectedPost.Address;
            categoryLabel.Text = selectedPost.CategoryName;
            coordinatesLabel.Text = selectedPost.Latitude + "," + selectedPost.Longitude;
            distanceLabel.Text = selectedPost.Distance.ToString() + " m";
            experienceEntry.Text = selectedPost.Experience;
            venueLabel.Text = selectedPost.VenueName;
        }
    }
}
