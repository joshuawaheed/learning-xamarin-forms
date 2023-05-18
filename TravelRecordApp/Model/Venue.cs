﻿using System;
using System.Collections.Generic;
using TravelRecordApp.Helpers;

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

    public class Category
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string PluralName { get; set; }
        public string ShortName { get; set; }
        public bool Primary { get; set; }
    }

    public class Venue
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Location Location { get; set; }
        public List<Category> Categories { get; set; }
    }

    public class Response
    {
        public List<Venue> Venues { get; set; }
    }

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
