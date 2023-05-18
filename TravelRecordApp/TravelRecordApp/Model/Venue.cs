using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TravelRecordApp.Model
{
    public class Venue
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Location Location { get; set; }
        public List<Category> Categories { get; set; }

        public static async Task<List<Venue>> GetVenues(double latitude, double longitude)
        {
            var venues = new List<Venue>();

            var url = VenueRoot.GenerateUrl(latitude, longitude);

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                var json = await response.Content.ReadAsStringAsync();

                var venueRoot = JsonConvert.DeserializeObject<VenueRoot>(json);

                venues = venueRoot.Response.Venues;
            }

            return venues;
        }
    }
}
