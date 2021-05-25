using System;
using SQLite;

namespace TravelRecordApp.Model
{
    public class Post
    {
        [MaxLength(250)]
        public string Experience { get; set; }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    }
}
