using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace QPlanApp.Models
{
    public class Location
    {
        [JsonProperty(PropertyName = "latitude")]
        public double Latitude { get; set; }
        [JsonProperty(PropertyName = "longitude")]
        public double Longitude { get; set; }
    }

    public class Restaurant
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "type")]
        public int Type { get; set; }
        [JsonProperty(PropertyName = "location")]
        public Location Location { get; set; }
        [JsonProperty(PropertyName = "distance")]
        public double Distance { get; set; }
        [JsonProperty(PropertyName = "address")]
        public string Address { get; set; }
        [JsonProperty(PropertyName = "city")]
        public string City { get; set; }
        [JsonProperty(PropertyName = "postalCode")]
        public string PostalCode { get; set; }
        [JsonProperty(PropertyName = "phone")]
        public string Phone { get; set; }
        [JsonProperty(PropertyName = "categories")]
        public List<string> Categories { get; set; }
        [JsonProperty(PropertyName = "rating")]
        public int Rating { get; set; }
        [JsonProperty(PropertyName = "coverUrl")]
        public string CoverUrl { get; set; }
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

    }

    public class RootObject
    {
        [JsonProperty(PropertyName = "restaurants")]
        public List<Restaurant> Restaurants { get; set; }
        [JsonProperty(PropertyName = "success")]
        public bool Success { get; set; }
        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }
    }

}


