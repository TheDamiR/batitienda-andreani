using Newtonsoft.Json;
using System.Collections.Generic;

namespace Andreani.Models.Shipping
{
    public class ShippingTracesResponse : BaseModel
    {
        [JsonProperty("eventos")]
        public IList<ShippingTracesEvent> Events { get; set; }
    }
}
