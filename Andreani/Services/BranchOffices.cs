using Andreani.Clients;
using Andreani.Models;
using System.Collections.Generic;

namespace Andreani.Services
{
    public class BranchOffices : Service
    {
        public BranchOffices(string endpoint) : base(endpoint)
        {
            Client = new RestClient(endpoint);
        }

        public BranchOfficeResponse Get()
        {
            BranchOfficeResponse response = null;
            var result = Client.Get("/v1/sucursales");

            if (IsOkResponse(result))
            {
                response = new BranchOfficeResponse
                {
                    BranchOffices = Model.ToObject<IList<BranchOffice>>(result.Response)
                };
            }
            else
            {
                BuildError(result);
            }

            return response;
        }
    }
}
