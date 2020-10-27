using Newtonsoft.Json;
using System.Collections.Generic;

namespace Andreani.Models
{
    public class BranchOffice
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "nomenclatura")]
        public string Nomenclature { get; set; }

        [JsonProperty(PropertyName = "descripcion")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "horarioDeAtencion")]
        public string HoursOperation { get; set; }

        [JsonProperty(PropertyName = "direccion")]
        public Address Address { get; set; }

        [JsonProperty(PropertyName = "telefonos")]
        public IList<Phone> Phones { get; set; }

        [JsonProperty(PropertyName = "geocoordenadas")]
        public Geocoordinates Geocoordinates { get; set; }

        [JsonProperty(PropertyName = "datosAdicionales")]
        public IList<AdditionalData> AdditionalData { get; set; }

        [JsonProperty(PropertyName = "tipo")]
        public string Type { get; set; }
    }
}
