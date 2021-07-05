using SQLite;

namespace TravelRecordApp.Model
{
    public class Post
    {
        public string Address { get; set; }

        public string CategoryId { get; set; }

        public string CategoryName { get; set; }

        public int Distance { get; set; }

        [MaxLength(250)]
        public string Experience { get; set; }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public int UserId { get; set; }

        public string VenueName { get; set; }
    }
}
