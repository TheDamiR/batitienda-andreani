using Newtonsoft.Json;
using System.Collections.Generic;

namespace Andreani.Models.Orders
{
    public class OrderPackage
    {
        [JsonProperty("numeroDeBulto")]
        public string PackageNumber { get; set; }

        [JsonProperty("numeroDeEnvio")]
        public string ShippingNumber { get; set; }

        [JsonProperty("totalizador")]
        public string Tote { get; set; }

        [JsonProperty("linking")]
        public IList<AdditionalData> Linking { get; set; }
    }
}
