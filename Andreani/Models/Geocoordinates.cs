using Newtonsoft.Json;

namespace Andreani.Models
{
    public class Geocoordinates
    {
        [JsonProperty(PropertyName = "elevacion")]
        public int Elevation { get; set; }

        [JsonProperty(PropertyName = "latitud")]
        public double Latitude { get; set; }

        [JsonProperty(PropertyName = "longitud")]
        public double Longitude { get; set; }
    }
}
