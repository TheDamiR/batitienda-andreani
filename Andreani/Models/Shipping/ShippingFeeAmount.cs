using Newtonsoft.Json;

namespace Andreani.Models.Shipping
{
    public class ShippingFeeAmount
    {
        [JsonProperty("seguroDistribucion")]
        public double DistributionInsurance { get; set; }

        [JsonProperty("distribucion")]
        public double Distribution { get; set; }

        [JsonProperty("total")]
        public double Total { get; set; }
    }
}
