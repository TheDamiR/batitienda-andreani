using Newtonsoft.Json;
using System.Collections.Generic;

namespace Andreani.Models.Shipping
{
    public class ShippingListResponse : BaseModel
    {
        [JsonProperty("envios")]
        public IList<ShippingResponse> Shipping { get; set; }
    }
}
