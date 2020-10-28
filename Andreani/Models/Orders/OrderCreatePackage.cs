using Newtonsoft.Json;
using System.Collections.Generic;

namespace Andreani.Models.Orders
{
    public class OrderCreatePackage
    {
        [JsonProperty("kilos")]
        public double Kilos { get; set; }

        [JsonProperty("largoCm")]
        public double Length { get; set; }

        [JsonProperty("altoCm")]
        public double Height { get; set; }

        [JsonProperty("anchoCm")]
        public double Width { get; set; }

        [JsonProperty("volumenCm")]
        public double Volume { get; set; }

        [JsonProperty("valorDeclaradoConImpuestos")]
        public double DeclaredAmountWithTaxes { get; set; }

        [JsonProperty("valorDeclaradoSinImpuestos")]
        public double DeclaredAmountWithoutTaxes { get; set; }

        [JsonProperty("descripcion")]
        public string Description { get; set; }

        //Numero de tracking del envío en caso de tener una pre-numeración asignada. Opcional.
        [JsonProperty("numeroDeEnvio")]
        public string ShippingNumber { get; set; }

        [JsonProperty("referencias")]
        public IList<AdditionalData> References { get; set; }
    }
}
