using Newtonsoft.Json;
using System.Collections.Generic;

namespace Andreani.Models
{
    public class Address
    {
        [JsonProperty(PropertyName = "localidad")]
        public string Location { get; set; }

        [JsonProperty(PropertyName = "region")]
        public string Region { get; set; }

        [JsonProperty(PropertyName = "pais")]
        public string Country { get; set; }

        [JsonProperty(PropertyName = "codigoPostal")]
        public string PostalCode { get; set; }

        [JsonProperty(PropertyName = "componentesDeDireccion")]
        public IList<AddressComponent> AddressComponents { get; set; }
    }
}
