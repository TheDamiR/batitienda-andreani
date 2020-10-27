using Newtonsoft.Json;

namespace Andreani.Models
{
    public class AdditionalData
    {
        [JsonProperty(PropertyName = "meta")]
        public string Meta { get; set; }

        [JsonProperty(PropertyName = "contenido")]
        public string Content { get; set; }
    }
}
