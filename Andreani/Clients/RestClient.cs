using Andreani.Exceptions;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Collections.Generic;

namespace Andreani.Clients
{
    public class RestClient
    {
        protected string Endpoint;
        protected Dictionary<string, string> Headers;
        protected string ContentType;
        public ResponseException ResponseException;

        #region Constants

        public const string CONTENT_TYPE_TEXT_HTML = "text/html";
        public const string CONTENT_TYPE_APP_XML = "application/xml";
        public const string CONTENT_TYPE_APP_JSON = "application/json";
        public const string CONTENT_TYPE_APP_X_WWW_FORM = "application/x-www-form-urlencoded";
        protected const string METHOD_POST = "POST";
        protected const string METHOD_GET = "GET";
        protected const string METHOD_PUT = "PUT";
        protected const string METHOD_DELETE = "DELETE";

        #endregion


        public RestClient(string endpoint, Dictionary<string, string> headers = null)
        {
            Endpoint = endpoint;
            Headers = new Dictionary<string, string>();

            SetHeaders(headers);
        }

        public RestClient(string endpoint, string contentType, Dictionary<string, string> headers = null)
        {
            Endpoint = endpoint;
            ContentType = contentType;
            Headers = new Dictionary<string, string>();

            SetHeaders(headers);
        }

        public void AddHeaders(Dictionary<string, string> headers)
        {
            SetHeaders(headers);
        }

        public void AddHeaders(string header, string value)
        {
            var headers = new Dictionary<string, string>()
            {
                { header, value }
            };

            SetHeaders(headers);
        }

        public void AddContentType(string contentType)
        {
            ContentType = contentType;
        }

        public RestResponse Get(string url, string data = null)
        {
            string uri = Endpoint + url + data;

            var httpWebRequest = Initialize(uri, METHOD_GET);

            return Request(httpWebRequest);
        }

        public RestResponse Post(string url, string data = null)
        {
            string uri = Endpoint + url;

            var httpWebRequest = Initialize(uri, METHOD_POST);

            if (!string.IsNullOrEmpty(data))
            {
                var bytes = Encoding.GetEncoding("ISO-8859-1").GetBytes(data);
                httpWebRequest.ContentLength = bytes.Length;

                using var writeStream = httpWebRequest.GetRequestStream();
                writeStream.Write(bytes, 0, bytes.Length);
            }

            return Request(httpWebRequest);
        }

        public RestResponse Delete(string url)
        {
            string uri = Endpoint + url;

            var httpWebRequest = Initialize(uri, METHOD_DELETE);
            httpWebRequest.ContentType = null;

            return Request(httpWebRequest);
        }

        public RestResponse Put(string url, string data = null)
        {
            string uri = Endpoint + url;

            var httpWebRequest = Initialize(uri, METHOD_PUT);

            if (!string.IsNullOrEmpty(data))
            {
                var bytes = Encoding.GetEncoding("ISO-8859-1").GetBytes(data);
                httpWebRequest.ContentLength = bytes.Length;

                using var writeStream = httpWebRequest.GetRequestStream();
                writeStream.Write(bytes, 0, bytes.Length);
            }

            return Request(httpWebRequest);
        }

        private void SetHeaders(Dictionary<string, string> headers = null)
        {
            if (headers != null)
            {
                foreach (var h in headers)
                {
                    Headers.Add(h.Key, h.Value);
                }
            }
        }

        private HttpWebRequest Initialize(string uri, string method)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
            httpWebRequest.Method = method;

            httpWebRequest.ContentLength = 0;
            httpWebRequest.Accept = CONTENT_TYPE_APP_JSON + "," + CONTENT_TYPE_APP_XML;

            if (!string.IsNullOrEmpty(ContentType))
            {
                httpWebRequest.ContentType = ContentType;
            } 
            else
            {
                httpWebRequest.ContentType = CONTENT_TYPE_APP_JSON;
            }

            if (Headers?.Count > 0)
            {
                foreach (var h in Headers)
                {
                    httpWebRequest.Headers.Add(h.Key, h.Value);
                }
            }

            return httpWebRequest;
        }

        private RestResponse Request(HttpWebRequest httpWebRequest)
        {
            var result = new RestResponse
            {
                Response = string.Empty
            };

            try
            {
                using var response = (HttpWebResponse)httpWebRequest.GetResponse();
                result.StatusCode = (int)response.StatusCode;
                result.StatusDescription = response.StatusDescription;
                result.Headers = response.Headers;

                if (response.StatusCode != HttpStatusCode.OK && response.StatusCode != HttpStatusCode.Created && response.StatusCode != HttpStatusCode.NoContent)
                {
                    var message = string.Format("Request failed. Received HTTP {0}", response.StatusCode);
                    result.Response = message;
                }
                else
                {
                    using var responseStream = response.GetResponseStream();
                    if (responseStream != null)
                    {
                        using var reader = new StreamReader(responseStream);
                        result.Response = reader.ReadToEnd();
                    }
                }
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    var response = (HttpWebResponse)ex.Response;
                    result.StatusCode = (int)response.StatusCode;
                    result.StatusDescription = response.StatusDescription;

                    using var responseStream = response.GetResponseStream();
                    if (responseStream != null)
                    {
                        using var reader = new StreamReader(responseStream);
                        result.Response = reader.ReadToEnd();
                    }
                }
                else
                {
                    result.StatusCode = 500;
                    result.StatusDescription = "Internal Server Error";
                    result.Response = ex.Message;
                }
            }
            catch (Exception ex)
            {
                result.StatusCode = 500;
                result.StatusDescription = "Internal Server Error";
                result.Response = ex.Message;
            }

            return result;
        }
    }
}
