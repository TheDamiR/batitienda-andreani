using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Andreani.Models.Shipping
{
    public class ShippingSingleResponse : BaseModel
    {
        [JsonProperty("numeroDeTracking")]
        public string NumeroDeTracking { get; set; }

        [JsonProperty("contrato")]
        public string Contrato { get; set; }

        [JsonProperty("estado")]
        public string Estado { get; set; }

        [JsonProperty("sucursalDeDistribucion")]
        public ShippingDistributionBranchOffice SucursalDeDistribucion { get; set; }

        [JsonProperty("fechaCreacion")]
        public DateTime FechaCreacion { get; set; }

        [JsonProperty("destino")]
        public ShippingDestination Destino { get; set; }

        [JsonProperty("remitente")]
        public ShippingSender Remitente { get; set; }

        [JsonProperty("destinatario")]
        public ShippingRecipient Destinatario { get; set; }

        [JsonProperty("bultos")]
        public List<ShippingPackage> Bultos { get; set; }

        [JsonProperty("referencias")]
        public List<string> Referencias { get; set; }
    }

    public class ShippingListResponse : BaseModel
    {
        [JsonProperty("envios")]
        public List<ShippingSingleResponse> Envios { get; set; }
    }
}
