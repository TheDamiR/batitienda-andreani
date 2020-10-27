using Newtonsoft.Json;

namespace Andreani.Models
{
    public class Province
    {
        [JsonProperty(PropertyName = "meta")]
        public string Meta { get; set; }

        [JsonProperty(PropertyName = "contenido")]
        public string Content { get; set; }
    }
}
