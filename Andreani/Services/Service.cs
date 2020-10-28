using Andreani.Clients;
using Andreani.Exceptions;
using Andreani.Models;
using System;
using System.Text;

namespace Andreani.Services
{
    public abstract class Service
    {
        protected ResponseException ResponseException;
        protected RestClient Client;
        protected string Endpoint;

        protected Service(string endpoint)
        {
            Endpoint = endpoint;
        }

        protected string GetCredentials(string username, string password)
        {
            var enconded = Encoding.GetEncoding("ISO-8859-1").GetBytes(username + ":" + password);
            return Convert.ToBase64String(enconded);
        }

        protected bool IsOkResponse(RestResponse response)
        {
            return response.StatusCode == 200 && !string.IsNullOrWhiteSpace(response.Response);
        }

        protected bool IsErrorResponse(RestResponse response)
        {
            return response.StatusCode >= 400 && response.StatusCode <= 500;
        }

        protected void BuildError(RestResponse response)
        {
            if (IsErrorResponse(response))
            {
                var ex = new BuildException(response);
                ResponseException = ex.BuildError();
            }
        }

        public ErrorResponse GetResponseException()
        {
            return ResponseException?.GetErrorResponse();
        }
    }
}
