using Newtonsoft.Json;
using System.Collections.Generic;

namespace Andreani.Models.Orders.Parameters
{
    public class OrderCreateParameters : BaseModel
    {
        [JsonProperty("contrato")]
        public string CodeContract { get; set; }
        
        [JsonProperty("productoAEntregar")]
        public string DescriptionProductToDeliver { get; set; }

        [JsonProperty("productoARetirar")]
        public string DescriptionProductToWithdraw { get; set; }

        [JsonProperty("tipoProducto")]
        public string CategoryProductToDeliver { get; set; }

        [JsonProperty("categoriaFacturacion")]
        public string BillingCategory { get; set; }

        [JsonProperty("fechaDeEntrega")]
        public OrderDateDelivery DateDelivery { get; set; }

        [JsonProperty("tipoServicio")]
        public string TypeService { get; set; }

        [JsonProperty("sucursalClienteID")]
        public string ClientBranchId { get; set; }

        [JsonProperty("origen")]
        public OrderOrigin Origin { get; set; }

        [JsonProperty("destino")]
        public OrderDestination Destination { get; set; }

        [JsonProperty("remitenteremitente")]
        public OrderSender Sender { get; set; }

        [JsonProperty("remito")]
        public OrderRemito Remito { get; set; }

        [JsonProperty("destinatario")]
        public IList<OrderRecipient> Recipients { get; set; }

        [JsonProperty("bultos")]
        public IList<OrderCreatePackage> Packages { get; set; }
    }
}
