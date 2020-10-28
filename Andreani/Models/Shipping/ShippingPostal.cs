using Newtonsoft.Json;

namespace Andreani.Models.Shipping
{
    public class ShippingPostal
    {
        [JsonProperty("localidad")]
        public string Location { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("_comment")]
        public string Comment { get; set; }

        [JsonProperty("pais")]
        public string Country { get; set; }

        [JsonProperty("direccion")]
        public string Address { get; set; }

        [JsonProperty("codigoPostal")]
        public string PostalCode { get; set; }
    }
}
