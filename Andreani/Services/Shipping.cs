using Andreani.Services.Data;
using Andreani.Clients;
using Andreani.Models.Shipping;
using Andreani.Models.Shipping.Parameters;
using System.Collections.Generic;

namespace Andreani.Services
{
    public class Shipping : Service
    {
        private ShippingData Data;

        public Shipping(string endpoint, string token) : base(endpoint)
        {
            
            var headers = new Dictionary<string, string>()
            {
                { "x-authorization-token", token }
            };


            Data = new ShippingData();
            Client = new RestClient(endpoint, headers);
        }

        public ShippingFeeResponse ShippingFee(ShippingFeeParameters data)
        {
            var response = new ShippingFeeResponse();
            var result = Client.Get("/v1/tarifas", Data.ShippingFee(data));

            if (IsOkResponse(result))
            {
                response = response.ToObject<ShippingFeeResponse>(result.Response);
            }
            else
            {
                BuildError(result);
            }

            return response;
        }

        public ShippingTracesResponse GetShippingTraces(string number)
        {
            var response = new ShippingTracesResponse();
            var result = Client.Get(string.Format("/v1/envios/{0}/trazas", number));

            if (IsOkResponse(result))
            {
                response = response.ToObject<ShippingTracesResponse>(result.Response);
            }
            else
            {
                BuildError(result);
            }

            return response;
        }

        public ShippingResponse GetShipping(string number)
        {
            var response = new ShippingResponse();
            var result = Client.Get(string.Format("/v1/envios/{0}", number));

            if (IsOkResponse(result))
            {
                response = response.ToObject<ShippingResponse>(result.Response);
            }
            else
            {
                BuildError(result);
            }

            return response;
        }

        public ShippingListResponse ShippingTracking(ShippingTrackingParameters data)
        {
            var response = new ShippingListResponse();
            var result = Client.Get("/v1/envios", Data.ShippingTracking(data));

            if (IsOkResponse(result))
            {
                response = response.ToObject<ShippingListResponse>(result.Response);
            }
            else
            {
                BuildError(result);
            }

            return response;
        }
    }
}
