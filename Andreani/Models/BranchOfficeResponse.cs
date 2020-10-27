using System.Collections.Generic;

namespace Andreani.Models
{
    public class BranchOfficeResponse : BaseModel
    {
        public IList<BranchOffice> BranchOffices { get; set; }
    }
}
