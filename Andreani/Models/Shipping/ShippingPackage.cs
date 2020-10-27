using Newtonsoft.Json;

namespace Andreani.Models.Shipping
{
    public class ShippingPackage
    {
        [JsonProperty("kilos")]
        public double Kilos { get; set; }

        [JsonProperty("valorDeclaradoConImpuestos")]
        public int ValorDeclaradoConImpuestos { get; set; }

        [JsonProperty("IdDeProducto")]
        public string IdDeProducto { get; set; }

        [JsonProperty("volumen")]
        public int Volumen { get; set; }
    }
}
