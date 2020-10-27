using Newtonsoft.Json;

namespace Andreani.Models.Shipping
{
    public class ShippingDistributionBranchOffice
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("nomenclatura")]
        public string Nomenclatura { get; set; }

        [JsonProperty("descripcion")]
        public string Descripcion { get; set; }
    }
}
