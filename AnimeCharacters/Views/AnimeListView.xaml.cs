using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using AnimeCharacters.Models;
using Xamarin.Forms;

namespace AnimeCharacters.Views
{
    public partial class AnimeListView : ContentPage
    {
        ObservableCollection<Anime> anime = new ObservableCollection<Anime>();

        public AnimeListView()
        {
            InitializeComponent();
            SetAnimeList();
            animeListView.ItemsSource = anime;
        }

        public void AnimeListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var anime = e.CurrentSelection[0] as Anime;
            var charactersView = new CharactersListView(anime);
            Navigation.PushAsync(charactersView);
        }

        private void SetAnimeList()
        {
            anime = new ObservableCollection<Anime>()
            {
                new Anime
                {
                    Characters = new List<Character>()
                    {
                        new Character
                        {
                            ImageUrl = "tanjiroavatar.jpg",
                            Name = "Tanjiro",
                            Description = ""
                        },

                        new Character
                        {
                            ImageUrl = "zenitsuavatar.jpg",
                            Name = "Zenitsu",
                            Description = ""
                        }
                    },
                    ImageUrl = "demonslayerlogo.webp",
                    Name = "Demon Slayer",
                    ReleaseDate = new DateTime(2019, 4, 16)
                },
                new Anime
                {
                    Characters = new List<Character>()
                    {
                        new Character
                        {
                            ImageUrl = "gokuavatar.png",
                            Name = "Goku",
                            Description = ""
                        },

                        new Character
                        {
                            ImageUrl = "vegetaavatar.png",
                            Name = "Vegeta",
                            Description = ""
                        }
                    },
                    ImageUrl = "dragonballsuperlogo.webp",
                    Name = "Dragon Ball Super",
                    ReleaseDate = new DateTime(2015, 7, 5)
                },
                new Anime
                {
                    Characters = new List<Character>()
                    {
                        new Character
                        {
                            ImageUrl = "emmaavatar.png",
                            Name = "Emma",
                            Description = ""
                        },

                        new Character
                        {
                            ImageUrl = "normanavatar.jpg",
                            Name = "Norman",
                            Description = ""
                        }
                    },
                    ImageUrl = "thepromisedneverlandlogo.png",
                    Name = "The Promised Neverland",
                    ReleaseDate = new DateTime(2019, 1, 11)
                }
            };
        }
    }
}
