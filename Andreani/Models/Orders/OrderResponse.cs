using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Andreani.Models.Orders
{
    public class OrderResponse : BaseModel
    {
        [JsonProperty("estado")]
        public string Status { get; set; }

        [JsonProperty("tipo")]
        public string Type { get; set; }

        [JsonProperty("sucursalDeDistribucion")]
        public BranchOfficeDetail DistributionBranchOffice { get; set; }

        [JsonProperty("sucursalDeRendicion")]
        public BranchOfficeDetail SurrenderBranchOffice { get; set; }

        [JsonProperty("sucursalDeImposicion")]
        public BranchOfficeDetail ImpositionBranchOffice { get; set; }

        [JsonProperty("fechaCreacion")]
        public DateTime CreationDate { get; set; }

        [JsonProperty("zonaDeReparto")]
        public string DeliveryZone { get; set; }

        [JsonProperty("numeroDePermisionaria")]
        public string PermitNumber { get; set; }

        [JsonProperty("descripcionServicio")]
        public string DescriptionService { get; set; }

        [JsonProperty("etiquetaRemito")]
        public string RemitoLabel { get; set; }

        [JsonProperty("bultos")]
        public IList<OrderPackage> Packages { get; set; }

        [JsonProperty("fechaEstimadaDeEntrega")]
        public string EstimatedDeliveryDate { get; set; }

        [JsonProperty("huellaDeCarbono")]
        public string CarbonFootprint { get; set; }

        [JsonProperty("gastoEnergetico")]
        public string EnergyExpenditure { get; set; }
    }
}
