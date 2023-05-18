using System;
namespace TravelRecordApp.Helpers
{
    public class Constants
    {
        public const string VENUE_SEARCH = "https://api.foursquare.com/v2" +
            "/venues/search" +
            "?ll={0},{1}" +
            "&client_id={2}" +
            "&client_secret={3}" +
            "&v={4}";

        public const string CLIENT_ID = "5ELW1VYO3PBQLRV0NLGPNAEQSU4A00KXCUGF2AK0D0JLKM3Z";

        public const string CLIENT_SECRET = "CDUTRTZAMUD3YNAVKOOZTLNTMWTUJYMRRHF4R044BEQU2V0U";
    }
}
