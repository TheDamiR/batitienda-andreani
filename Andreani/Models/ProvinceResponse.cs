using System.Collections.Generic;

namespace Andreani.Models
{
    public class Province
    {
        public string meta { get; set; }
        public string contenido { get; set; }
    }

    public class ProvinceResponse : BaseModel
    {
        public IList<Province> Provinces { get; set; }
    }
}
