using Andreani.Clients;
using Andreani.Models;
using Newtonsoft.Json;
using System.Net;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace Andreani.Exceptions
{
    public class BuildException
    {
        private string Response;
        private int StatusCode;
        private string StatusDescription;

        public BuildException(RestResponse data)
        {
            Response = data.Response;
            StatusCode = data.StatusCode;
            StatusDescription = data.StatusDescription;
        }

        private ResponseException ResponseUnknown(string detail = "unknown")
        {
            return new ResponseException(new ErrorResponse
            {
                Title = StatusDescription,
                Status = StatusCode,
                Detail = detail
            });
        }

        private ResponseException ResponseInternalErrorServer()
        {
            try
            {
                var error = JsonConvert.DeserializeObject<ErrorFaultResponse>(Response);

                return new ResponseException(new ErrorResponse
                {
                    Title = StatusDescription,
                    Status = StatusCode,
                    Detail = error.Message
                });
            }
            catch (JsonException)
            {
                return ResponseUnknown("something went wrong :(");
            }
        }

        private ResponseException ResponseBadRequest()
        {
            try
            {
                var error = JsonConvert.DeserializeObject<ErrorResponse>(Response);
                return new ResponseException(error);
            }
            catch (JsonException) { 
                return ResponseUnknown();
            }
        }

        private ResponseException ResponseUnauthorized()
        {
            try
            {
                var xml = XDocument.Parse(Response);
                XNamespace ns = "http://schemas.xmlsoap.org/soap/envelope/";

                var fault = xml.Descendants(ns + "Fault").FirstOrDefault();
                var faultCode = fault?.Descendants("faultcode").FirstOrDefault()?.Value ?? "";
                var faultString = fault?.Descendants("faultstring").FirstOrDefault()?.Value ?? "unknown";

                return new ResponseException(new ErrorResponse
                {
                    Title = StatusDescription,
                    Status = StatusCode,
                    Detail = $"{faultCode} {faultString}"
                });
            }
            catch (XmlException)
            {
                try
                {
                    var error = JsonConvert.DeserializeObject<ErrorFaultResponse>(Response);

                    return new ResponseException(new ErrorResponse
                    {
                        Title = StatusDescription,
                        Status = StatusCode,
                        Detail = error.Message
                    });
                }
                catch (JsonException)
                {
                    return ResponseUnknown();
                }
            }
        }

        public ResponseException BuildError()
        {
            if (StatusCode == (int)HttpStatusCode.Unauthorized)
            {
                return ResponseUnauthorized();
            }
            else if (StatusCode == (int)HttpStatusCode.BadRequest)
            {
                return ResponseBadRequest();
            } 
            else if (StatusCode == (int)HttpStatusCode.InternalServerError)
            {
                return ResponseInternalErrorServer();
            }
            else
            {
                return ResponseUnknown();
            }
        }
    }
}
