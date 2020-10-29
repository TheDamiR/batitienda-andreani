using Andreani.Clients;
using Andreani.Models;
using System.Collections.Generic;

namespace Andreani.Services
{
    public class Provinces : Service
    {
        public Provinces(string endpoint) : base(endpoint)
        {
            Client = new RestClient(endpoint);
        }

        public ProvinceResponse Get()
        {
            ProvinceResponse response = null;
            var result = Client.Get("/v1/regiones");

            if (IsOkResponse(result))
            {
                response = new ProvinceResponse
                {
                    Provinces = Model.ToObject<IList<Province>>(result.Response)
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
