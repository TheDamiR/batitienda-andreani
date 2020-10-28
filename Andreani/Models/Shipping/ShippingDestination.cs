using Newtonsoft.Json;

namespace Andreani.Models.Shipping
{
    public class ShippingDestination
    {
        [JsonProperty("Postal")]
        public ShippingPostal Postcard { get; set; }
    }
}
