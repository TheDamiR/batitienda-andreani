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
        protected string ApiVersion;

        #region Constants

        public const string CONTENT_TYPE_APP_JSON = "application/json";
        public const string CONTENT_TYPE_X_WWW = "application/x-www-form-urlencoded";
        protected const string METHOD_POST = "POST";
        protected const string METHOD_GET = "GET";
        protected const string METHOD_PUT = "PUT";
        protected const string METHOD_DELETE = "DELETE";

        #endregion


        public RestClient(string endpoint, Dictionary<string, string> headers = null)
        {
            Endpoint = endpoint;
            ApiVersion = "/v1/";
            Headers = new Dictionary<string, string>();

            SetHeaders(headers);
        }

        public RestClient(string endpoint, string apiVersion, Dictionary<string, string> headers = null)
        {
            Endpoint = endpoint;
            ApiVersion = "/" + apiVersion + "/";
            Headers = new Dictionary<string, string>();

            SetHeaders(headers);
        }

        public RestClient(string endpoint, string apiVersion, string contentType, Dictionary<string, string> headers = null)
        {
            Endpoint = endpoint;
            ApiVersion = "/" + apiVersion + "/";
            ContentType = contentType;
            Headers = new Dictionary<string, string>();

            SetHeaders(headers);
        }

        protected void SetHeaders(Dictionary<string, string> headers = null)
        {
            if (headers != null)
            {
                foreach (var key in headers.Keys)
                {
                    Headers.Add(key, headers[key]);
                }
            }
        }

        public void AddHeaders(Dictionary<string, string> headers = null)
        {
            if (headers != null)
            {
                foreach (var key in headers.Keys)
                {
                    Headers.Add(key, headers[key]);
                }
            }
        }

        public void AddContentType(string contentType)
        {
            ContentType = contentType;
        }

        public RestResponse Get(string url, string data = null)
        {
            string uri = Endpoint + ApiVersion + url + data;

            var httpWebRequest = Initialize(uri, METHOD_GET);

            return DoRequest(httpWebRequest);
        }

        public RestResponse Post(string url, string data = null)
        {
            string uri = Endpoint + ApiVersion  + url;

            var httpWebRequest = Initialize(uri, METHOD_POST);

            if (!string.IsNullOrEmpty(data))
            {
                var bytes = Encoding.GetEncoding("iso-8859-1").GetBytes(data);
                httpWebRequest.ContentLength = bytes.Length;

                using var writeStream = httpWebRequest.GetRequestStream();
                writeStream.Write(bytes, 0, bytes.Length);
            }

            return DoRequest(httpWebRequest);
        }

        public RestResponse Delete(string url)
        {
            string uri = Endpoint + ApiVersion + url;

            var httpWebRequest = Initialize(uri, METHOD_DELETE);
            httpWebRequest.ContentType = null;

            return DoRequest(httpWebRequest);
        }

        public RestResponse Put(string url, string data = null)
        {
            string uri = Endpoint + ApiVersion + url;

            var httpWebRequest = Initialize(uri, METHOD_PUT);

            if (!string.IsNullOrEmpty(data))
            {
                var bytes = Encoding.GetEncoding("iso-8859-1").GetBytes(data);
                httpWebRequest.ContentLength = bytes.Length;

                using var writeStream = httpWebRequest.GetRequestStream();
                writeStream.Write(bytes, 0, bytes.Length);
            }

            return DoRequest(httpWebRequest);
        }

        protected HttpWebRequest Initialize(string uri, string method)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
            httpWebRequest.Method = method;

            httpWebRequest.ContentLength = 0;

            if (!string.IsNullOrEmpty(ContentType))
                httpWebRequest.ContentType = ContentType;
            else
                httpWebRequest.ContentType = CONTENT_TYPE_APP_JSON;

            if (Headers != null && Headers.Count > 0)
            {
                foreach (string key in Headers.Keys)
                {
                    httpWebRequest.Headers.Add(key, Headers[key]);
                }
            }

            return httpWebRequest;
        }

        protected RestResponse DoRequest(HttpWebRequest httpWebRequest)
        {
            RestResponse result = new RestResponse();
            result.Response = string.Empty;

            try
            {
                using var response = (HttpWebResponse)httpWebRequest.GetResponse();
                result.StatusCode = (int)response.StatusCode;

                if (response.StatusCode != HttpStatusCode.OK && response.StatusCode != HttpStatusCode.Created
                    && response.StatusCode != HttpStatusCode.NoContent)
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
                    result.StatusCode = (int)((HttpWebResponse)ex.Response).StatusCode;
                    using var responseStream = ((HttpWebResponse)ex.Response).GetResponseStream();
                    if (responseStream != null)
                    {
                        using var reader = new StreamReader(responseStream);
                        result.Response = reader.ReadToEnd();
                    }
                }
                else
                {
                    result.StatusCode = 500;
                    result.Response = ex.Message;
                }
            }
            catch (Exception ex)
            {
                result.StatusCode = 500;
                result.Response = ex.Message;
            }

            return result;
        }
    }
}
