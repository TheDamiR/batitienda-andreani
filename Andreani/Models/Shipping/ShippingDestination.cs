using Newtonsoft.Json;

namespace Andreani.Models.Shipping
{
    public class ShippingDestination
    {
        [JsonProperty("Postal")]
        public ShippingPostcard Postal { get; set; }
    }
}
