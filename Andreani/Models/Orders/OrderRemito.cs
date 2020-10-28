using Newtonsoft.Json;

namespace Andreani.Models.Orders
{
    public class OrderRemito
    {
        [JsonProperty("numeroRemito")]
        public string NumberRemito { get; set; }

        [JsonProperty("complementarios")]
        public string[] Complementary { get; set; }
    }
}
