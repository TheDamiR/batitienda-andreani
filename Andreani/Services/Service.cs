using Andreani.Clients;

namespace Andreani.Services
{
    public abstract class Service
    {

        protected RestClient Client;
        protected string Endpoint;

        protected const int STATUS_OK = 200;
        protected const int STATUS_UNAUTHORIZED = 401;
        protected const int STATUS_BAD_REQUEST = 400;
        protected const int STATUS_INTERNAL_ERROR = 500;

        protected Service(string endpoint)
        {
            Endpoint = endpoint;
        }

        protected bool IsOkResponse(RestResponse response)
        {
            return response.StatusCode == STATUS_OK && !string.IsNullOrWhiteSpace(response.Response);
        }

        protected bool IsErrorResponse(int statusCode)
        {
            return statusCode >= 400 && statusCode < 500;
        }
    }
}
