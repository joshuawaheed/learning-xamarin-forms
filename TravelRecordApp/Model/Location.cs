using System.Collections.Generic;

namespace TravelRecordApp.Model
{
    public class Location
    {
        public string Address { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public int Distance { get; set; }
        public string PostalCode { get; set; }
        public string Cc { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public List<string> FormattedAddress { get; set; }
        public string CrossStreet { get; set; }
    }
}
