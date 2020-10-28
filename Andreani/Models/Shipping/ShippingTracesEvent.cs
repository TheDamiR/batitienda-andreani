using System;
using Newtonsoft.Json;

namespace Andreani.Models.Shipping
{
    public class ShippingTracesEvent
    {
        [JsonProperty("Fecha")]
        public DateTime Date { get; set; }

        [JsonProperty("Estado")]
        public string Status { get; set; }

        [JsonProperty("EstadoId")]
        public int StatusId { get; set; }

        [JsonProperty("Motivo")]
        public string Reason { get; set; }

        [JsonProperty("MotivoId")]
        public int ReasonId { get; set; }

        [JsonProperty("Submotivo")]
        public object SubReason { get; set; }

        [JsonProperty("SubmotivoId")]
        public int SubReasonId { get; set; }

        [JsonProperty("Sucursal")]
        public string BranchOffice { get; set; }

        [JsonProperty("SucursalId")]
        public int BranchOfficeId { get; set; }

        [JsonProperty("Ciclo")]
        public string Cycle { get; set; }
    }
}
