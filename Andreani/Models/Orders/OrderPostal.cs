using Newtonsoft.Json;
using System.Collections.Generic;

namespace Andreani.Models.Orders
{
    public class OrderPostal
    {
        [JsonProperty("codigoPostal")]
        public string PostalCode { get; set; }

        [JsonProperty("calle")]
        public string Street { get; set; }

        [JsonProperty("numero")]
        public string Number { get; set; }

        [JsonProperty("localidad")]
        public string Location { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("pais")]
        public string Country { get; set; }

        [JsonProperty("componentesDeDireccion")]
        public IList<AdditionalData> ComponentsAddress { get; set; }
    }
}
