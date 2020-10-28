using Newtonsoft.Json;
using System.Collections.Generic;

namespace Andreani.Models.Orders
{
    public class OrderSender
    {
        [JsonProperty("nombreCompleto")]
        public string FullName { get; set; }

        [JsonProperty("email")]
        public string EmailAddress { get; set; }

        [JsonProperty("documentoTipo")]
        public string DocumentType { get; set; }

        [JsonProperty("documentoNumero")]
        public string DocumentNumber { get; set; }

        [JsonProperty("telefonos")]
        public IList<Phone> Phones { get; set; }
    }
}
