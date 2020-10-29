using Andreani.Clients;
using Andreani.Exceptions;
using Andreani.Models;
using System.Collections.Generic;

namespace Andreani.Services
{
    public abstract class Service
    {
        protected Login Login;
        protected string Endpoint;
        protected ResponseException ResponseException;
        protected RestClient Client;
        protected BaseModel Model;

        protected Service(string endpoint, Login login)
        {
            Login = login;
            Endpoint = endpoint;
            Model = new BaseModel();
        }

        protected Service(string endpoint)
        {
            Endpoint = endpoint;
            Model = new BaseModel();
        }

        protected Dictionary<string, string> GetAuthorizationHeader()
        {
            return new Dictionary<string, string>()
            {
                { "x-authorization-token", Login?.Get() }
            };
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
