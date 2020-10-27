using Newtonsoft.Json;

namespace Andreani.Models.Shipping
{
    public class ShippingPostcard
    {
        [JsonProperty("localidad")]
        public string Localidad { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("_comment")]
        public string Comment { get; set; }

        [JsonProperty("pais")]
        public string Pais { get; set; }

        [JsonProperty("direccion")]
        public string Direccion { get; set; }

        [JsonProperty("codigoPostal")]
        public string CodigoPostal { get; set; }
    }
}
