using Newtonsoft.Json;

namespace Andreani.Models
{
    public class Phone
    {
        [JsonProperty(PropertyName = "tipo")]
        public int Type { get; set; }

        [JsonProperty(PropertyName = "numero")]
        public string Number { get; set; }
    }
}
