using Newtonsoft.Json;

namespace Andreani.Models.Orders
{
    public class OrderDestination
    {
        [JsonProperty("postal")]
        public OrderPostal Postal { get; set; }
    }
}
