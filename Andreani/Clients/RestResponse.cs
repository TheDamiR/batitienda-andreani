using System.Net;

namespace Andreani.Clients
{
    public class RestResponse
    {
        public int StatusCode { get; set; }
        public string StatusDescription { get; set; }
        public string Response { get; set; }
        public WebHeaderCollection Headers { get; set; }
    }
}
