using System.Collections.Generic;
using Newtonsoft.Json;
using Andreani.Clients;
using Andreani.Exceptions;
using Andreani.Models;

namespace Andreani.Services
{
    public class Provinces : Service
    {
        public Provinces(string endpoint, string token) : base(endpoint)
        {
            var headers = new Dictionary<string, string>
            {
                { "x-authorization-token", token }
            };

            Client = new RestClient(endpoint, headers);
        }

        public ProvinceResponse Execute()
        {
            var response = new ProvinceResponse();
            var result = Client.Get("regiones");

            if (IsOkResponse(result))
            {
                response.Provinces = response.ToObject<IList<Province>>(result.Response);
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
