using System;
using AnimeCharacters.Models;
using Xamarin.Forms;

namespace AnimeCharacters.Views
{
    public partial class CharactersListView : ContentPage
    {
        public CharactersListView(Anime anime)
        {
            InitializeComponent();
            animeDetail.BindingContext = anime;
            charactersListView.ItemsSource = anime.Characters;
        }

        void CharactersListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var character = e.CurrentSelection[0] as Character;
            var characterView = new CharacterView(character);
            Navigation.PushAsync(characterView);
        }
    }
}
