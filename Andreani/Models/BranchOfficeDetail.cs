using Newtonsoft.Json;

namespace Andreani.Models
{
    public class BranchOfficeDetail
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("nomenclatura")]
        public string Nomenclature { get; set; }

        [JsonProperty("descripcion")]
        public string Description { get; set; }
    }
}
