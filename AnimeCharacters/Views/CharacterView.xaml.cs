using AnimeCharacters.Models;
using Xamarin.Forms;

namespace AnimeCharacters.Views
{
    public partial class CharacterView : ContentPage
    {
        public CharacterView(Character character)
        {
            InitializeComponent();
            characterDetail.BindingContext = character;
        }
    }
}
