using System.Collections.Generic;
using Newtonsoft.Json;
using Andreani.Clients;
using Andreani.Models;
using Andreani.Exceptions;

namespace Andreani.Services
{
    public class BranchOffices : Service
    {
        public BranchOffices(string endpoint, string token) : base(endpoint)
        {
            var headers = new Dictionary<string, string>
            {
                { "x-authorization-token", token }
            };

            Client = new RestClient(endpoint, headers);
        }

        public BranchOfficeResponse Execute()
        {
            var response = new BranchOfficeResponse();
            var result = Client.Get("sucursales");

            if (IsOkResponse(result))
            {
                response.BranchOffices = response.ToObject<IList<BranchOffice>>(result.Response);
            }
            else
            {
                if (IsErrorResponse(result.StatusCode))
                {
                    throw new ResponseException(result.StatusCode.ToString(), JsonConvert.DeserializeObject<ErrorResponse>(result.Response));
                }
                else
                {
                    throw new ResponseException(result.StatusCode + " - " + result.Response);
                }
            }

            return response;
        }
    }
}
