using Newtonsoft.Json;

namespace Andreani.Models
{
    public class ErrorFaultResponse
    {
        [JsonProperty("errorcode")]
        public string Code { get; set; }

        [JsonProperty("faultcode")]
        public string Title { get; set; }

        [JsonProperty("faultstring")]
        public string Message { get; set; }
    }
}
