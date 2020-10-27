using Newtonsoft.Json;

namespace Andreani.Models.Shipping
{
    public class ShippingFeeResponse : BaseModel
    {
        [JsonProperty("pesoAforado")]
        public double ChargeableWeight { get; set; }

        [JsonProperty("tarifaSinIva")]
        public ShippingFeeAmount FeeWithoutIva { get; set; }

        [JsonProperty("tarifaConIva")]
        public ShippingFeeAmount FeeWithIva { get; set; }
    }
}
