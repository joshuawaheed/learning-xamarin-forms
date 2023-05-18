using System;
using System.Collections.Generic;

namespace AnimeCharacters.Models
{
    public class Anime
    {
        public Anime()
        {
            Characters = new List<Character>();
        }

        public IEnumerable<Character> Characters { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
