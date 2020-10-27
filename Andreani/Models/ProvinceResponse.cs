using System.Collections.Generic;

namespace Andreani.Models
{
    public class ProvinceResponse : BaseModel
    {
        public IList<Province> Provinces { get; set; }
    }
}
