using Andreani.Clients;
using Andreani.Models.Orders;
using Andreani.Models.Orders.Parameters;

namespace Andreani.Services
{
    public class Orders : Service
    {
        public Orders(string endpoint, Login login) : base(endpoint, login)
        {
            var headers = GetAuthorizationHeader();

            Client = new RestClient(endpoint, headers);
        }

        public OrderResponse Create(OrderCreateParameters data)
        {
            OrderResponse response = null;
            var result = Client.Post("/v2/ordenes-de-envio", Model.ToJson(data));

            if (IsOkResponse(result))
            {
                response = Model.ToObject<OrderResponse>(result.Response);
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
                response = ""; //...
            }
            else
            {
                BuildError(result);
            }

            return response;
        }

        public OrderResponse Get(string number)
        {
            OrderResponse response = null;
            var result = Client.Get(string.Format("/v2/ordenes-de-envio/{0}", number));

            if (IsOkResponse(result))
            {
                response = Model.ToObject<OrderResponse>(result.Response);
            }
            else
            {
                BuildError(result);
            }

            return response;
        }
    }
}
