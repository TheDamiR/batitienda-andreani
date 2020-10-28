using Andreani.Clients;
using Andreani.Models.Orders;
using Andreani.Models.Orders.Parameters;
using System.Collections.Generic;

namespace Andreani.Services
{
    public class Orders : Service
    {
        public Orders(string endpoint, string token) : base(endpoint)
        {
            var headers = new Dictionary<string, string>()
            {
                { "x-authorization-token", token }
            };

            Client = new RestClient(endpoint, headers);
        }

        public OrderResponse Create(OrderCreateParameters data)
        {
            var response = new OrderResponse();
            var result = Client.Post("/v2/ordenes-de-envio", data.ToJson(data));

            if (IsOkResponse(result))
            {
                response = response.ToObject<OrderResponse>(result.Response);
            }
            else
            {
                BuildError(result);
            }

            return response;
        }

        public string GetLabel(string number)
        {
            string response = null;
            var result = Client.Post(string.Format("/v2/ordenes-de-envio/{0}/etiquetas", number));

            if (IsOkResponse(result))
            {
                response = "";
            }
            else
            {
                BuildError(result);
            }

            return response;
        }

        public OrderResponse Get(string number)
        {
            var response = new OrderResponse();
            var result = Client.Get(string.Format("/v2/ordenes-de-envio/{0}", number));

            if (IsOkResponse(result))
            {
                response = response.ToObject<OrderResponse>(result.Response);
            }
            else
            {
                BuildError(result);
            }

            return response;
        }
    }
}
