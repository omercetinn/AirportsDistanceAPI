using Newtonsoft.Json;

namespace AirportsDistanceAPI.Domain.Resource.Models
{

    public class AirportsDetailsResultModel
    {
        public double distance { get; set; }

        public AirportsDetailsResultModel(double distance)
        {
            this.distance = distance;
        }


        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("country_iata")]
        public string country_iata { get; set; }

        [JsonProperty("city_iata")]
        public string city_iata { get; set; }

        [JsonProperty("iata")]
        public string iata { get; set; }

        [JsonProperty("timezone_region_name")]
        public string timezone_region_name { get; set; }

        [JsonProperty("rating")]
        public int rating { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("type")]
        public string type { get; set; }

        [JsonProperty("location")]
        public Location Locations { get; set; }

        public class Location
        {
            [JsonProperty("lon")]
            public double lon { get; set; }

            [JsonProperty("lat")]
            public double lat { get; set; }
        }
    }
}
