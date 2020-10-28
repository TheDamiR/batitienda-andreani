using Andreani.Clients;
using System.Collections.Generic;

namespace Andreani.Services
{
    public class Login : Service
    {
        public Login(string endpoint, string username, string password) : base(endpoint)
        {
            var credentials = GetCredentials(username, password);

            var headers = new Dictionary<string, string>()
            {
                { "Authorization", $"Basic {credentials}" }
            };

            Client = new RestClient(endpoint, headers);
        }

        public string Get()
        {
            string response = null;
            var result = Client.Get("/login");

            if (IsOkResponse(result))
            {
                return result.Headers?.Get("x-authorization-token");
            }
            else
            {
                BuildError(result);
            }

            return response;
        }
    }
}
