using Andreani.Clients;
using Andreani.Exceptions;
using Andreani.Models;
using Newtonsoft.Json;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace Andreani.Services
{
    public abstract class Service
    {
        protected ResponseException ResponseException;
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

        protected bool IsErrorResponse(RestResponse response)
        {
            return response.StatusCode >= STATUS_BAD_REQUEST && response.StatusCode < STATUS_INTERNAL_ERROR;
        }

        protected ResponseException BuildError(RestResponse response)
        {
            if (IsErrorResponse(response))
            {
                if (response.StatusCode == STATUS_UNAUTHORIZED)
                {
                    try
                    {
                        var xml = XDocument.Parse(response.Response);
                        XNamespace ns = "http://schemas.xmlsoap.org/soap/envelope/";

                        var fault = xml.Descendants(ns + "Fault").FirstOrDefault();
                        var faultCode = fault?.Descendants("faultcode").FirstOrDefault()?.Value ?? "unknown";
                        var faultString = fault?.Descendants("faultstring").FirstOrDefault()?.Value ?? "unknown";

                        return ResponseException = new ResponseException(new ErrorResponse 
                        { 
                            Title = response.StatusDescription,
                            Detail = faultCode + " - " + faultString,
                            Status = response.StatusCode.ToString()
                        });
                    } 
                    catch (XmlException) { }
                } 
                else if (response.StatusCode == STATUS_BAD_REQUEST)
                {
                    try
                    {
                        var error = JsonConvert.DeserializeObject<ErrorResponse>(response.Response);
                        return ResponseException = new ResponseException(error);
                    } catch (JsonException) { }
                }

                return ResponseException = new ResponseException(response);
            }

            return null;
        }

        public ErrorResponse GetResponseException()
        {
            return ResponseException.GetErrorResponse();
        }
    }
}
