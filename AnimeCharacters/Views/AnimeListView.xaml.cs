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
                            Description = "Tanjiro Kamado (竈門かまど 炭たん治じ郎ろう Kamado Tanjirō?) is the main protagonist of Demon Slayer: Kimetsu no Yaiba. He is a Demon Slayer in the Demon Slayer Corps, who joined to find a remedy to turn his sister, Nezuko Kamado, who was turned into a Demon, back into a human."
                        },

                        new Character
                        {
                            ImageUrl = "zenitsuavatar.jpg",
                            Name = "Zenitsu",
                            Description = "Zenitsu Agatsuma (我あが妻つま 善ぜん逸いつ Agatsuma Zen'itsu?) is one of the main protagonists of Demon Slayer: Kimetsu no Yaiba. He is a Demon Slayer in the Demon Slayer Corps."
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
                            Description = "Son Goku (孫そん悟ご空くう Son Gokū), born Kakarot (カカロット Kakarotto), is the main protagonist of the Dragon Ball metaseries. Goku is a Saiyan male originally sent to destroy Earth as an infant. However, a head injury at an early age alters his memory, ridding him of his initial destructive nature and allowing him to grow up to become one of Earth's greatest defenders. He constantly strives and trains to be the greatest warrior possible, which has kept the Earth and the universe safe from destruction many times."
                        },

                        new Character
                        {
                            ImageUrl = "vegetaavatar.png",
                            Name = "Vegeta",
                            Description = "Vegeta (ベジータ Bejīta), more specifically Vegeta IV (ベジータ四世 Bejīta Yonsei)[6], recognized as Prince Vegeta (ベジータ王子 Bejīta Ōji) is the prince of the fallen Saiyan race and one of the main characters of the Dragon Ball series."
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
                            Description = "Emma (エマ, Ema?) is the main protagonist of The Promised Neverland. Caring and extroverted, Emma often proves herself to be one of the most reliable orphans and is often seen surrounded by friends. She is known for her incredible ability to learn, capable athleticism, and ample optimism."
                        },

                        new Character
                        {
                            ImageUrl = "normanavatar.jpg",
                            Name = "Norman",
                            Description = "Norman (ノーマン, Nōman?) is one of the deuteragonists of The Promised Neverland alongside Ray. Norman is a math prodigy and a model student of Grace Field House, with intelligence that surpasses his peers and even adults. He is also known for being a genius strategist and planner, as well as unbeatable at the game of tag."
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
