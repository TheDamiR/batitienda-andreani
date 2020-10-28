using Newtonsoft.Json;

namespace Andreani.Models.Shipping
{
    public class ShippingPackage
    {
        [JsonProperty("IdDeProducto")]
        public string ProductId { get; set; }

        [JsonProperty("kilos")]
        public double Kilos { get; set; }

        [JsonProperty("valorDeclaradoConImpuestos")]
        public double DeclaredAmountWithTaxes { get; set; }

        [JsonProperty("volumen")]
        public double Volume { get; set; }
    }
}
