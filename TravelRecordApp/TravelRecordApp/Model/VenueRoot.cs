using System;
using TravelRecordApp.Helpers;

namespace TravelRecordApp.Model
{
    public class VenueRoot
    {
        public Response Response { get; set; }

        public static string GenerateUrl(double latitude, double longitude)
        {
            return string.Format(
                Constants.VENUE_SEARCH,
                latitude,
                longitude,
                Constants.CLIENT_ID,
                Constants.CLIENT_SECRET,
                DateTime.Now.ToString("yyyyMMdd"));
        }
    }
}
