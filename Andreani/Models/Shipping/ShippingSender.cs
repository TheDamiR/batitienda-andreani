using Newtonsoft.Json;

namespace Andreani.Models.Shipping
{
    public class ShippingSender
    {
        [JsonProperty("nombreYApellido")]
        public string NameAndSurname { get; set; }

        [JsonProperty("tipoYNumeroDeDocumento")]
        public string TypeAndNumberDocument { get; set; }

        [JsonProperty("eMail")]
        public string EmailAddress { get; set; }
    }
}
