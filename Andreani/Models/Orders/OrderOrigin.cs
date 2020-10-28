using Newtonsoft.Json;

namespace Andreani.Models.Orders
{
    public class OrderOrigin
    {
        [JsonProperty("postal")]
        public OrderPostal Postal { get; set; }
    }
}
