using Andreani.Services.Data;
using Andreani.Clients;
using Andreani.Models;
using Andreani.Models.Shipping;
using Andreani.Models.Shipping.Parameters;

namespace Andreani.Services
{
    public class Shipping : Service
    {
        private ShippingData Data;

        public Shipping(string endpoint, Login login) : base(endpoint, login)
        {
            Data = new ShippingData();
            Client = new RestClient(endpoint);
        }

        public ShippingFeeResponse ShippingFee(ShippingFeeParameters data)
        {
            ShippingFeeResponse response = null;
            var result = Client.Get("/v1/tarifas", Data.ShippingFee(data));

            if (IsOkResponse(result))
            {
                response = Model.ToObject<ShippingFeeResponse>(result.Response);
            }
            else
            {
                BuildError(result);
            }

            return response;
        }

        public ShippingTracesResponse GetShippingTraces(string number)
        {
            Client.AddHeaders(GetAuthorizationHeader());

            ShippingTracesResponse response = null;
            var result = Client.Get(string.Format("/v1/envios/{0}/trazas", number));

            if (IsOkResponse(result))
            {
                response = Model.ToObject<ShippingTracesResponse>(result.Response);
            }
            else
            {
                BuildError(result);
            }

            return response;
        }

        public ShippingResponse GetShipping(string number)
        {
            Client.AddHeaders(GetAuthorizationHeader());

            ShippingResponse response = null;
            var result = Client.Get(string.Format("/v1/envios/{0}", number));

            if (IsOkResponse(result))
            {
                response = Model.ToObject<ShippingResponse>(result.Response);
            }
            else
            {
                BuildError(result);
            }

            return response;
        }

        public ShippingListResponse ShippingTracking(ShippingTrackingParameters data)
        {
            Client.AddHeaders(GetAuthorizationHeader());

            ShippingListResponse response = null;
            var result = Client.Get("/v1/envios", Data.ShippingTracking(data));

            if (IsOkResponse(result))
            {
                response = Model.ToObject<ShippingListResponse>(result.Response);
            }
            else
            {
                BuildError(result);
            }

            return response;
        }
    }
}
