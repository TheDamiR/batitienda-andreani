using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Andreani.Models.Shipping
{
    public class ShippingResponse : BaseModel
    {
        [JsonProperty("numeroDeTracking")]
        public string NumberTracking { get; set; }

        [JsonProperty("contrato")]
        public string CodeContract { get; set; }

        [JsonProperty("estado")]
        public string Status { get; set; }

        [JsonProperty("sucursalDeDistribucion")]
        public BranchOfficeDetail DistributionBranchOffice { get; set; }

        [JsonProperty("fechaCreacion")]
        public DateTime CreationDate { get; set; }

        [JsonProperty("destino")]
        public ShippingDestination Destination { get; set; }

        [JsonProperty("remitente")]
        public ShippingSender Sender { get; set; }

        [JsonProperty("destinatario")]
        public ShippingRecipient Recipient { get; set; }

        [JsonProperty("bultos")]
        public IList<ShippingPackage> Packages { get; set; }

        [JsonProperty("referencias")]
        public IList<string> References { get; set; }
    }
}
