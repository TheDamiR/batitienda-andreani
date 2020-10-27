using Andreani.Clients;
using Andreani.Models;

namespace Andreani.Exceptions
{
    public class ResponseException
    {
        protected ErrorResponse ErrorResponse;

        public ResponseException(RestResponse response)
        {
            ErrorResponse = new ErrorResponse
            {
                Title = response.StatusDescription,
                Status = response.StatusCode.ToString()
            };
        }

        public ResponseException(ErrorResponse errorResponse)
        {
            ErrorResponse = errorResponse;
        }

        public ErrorResponse GetErrorResponse()
        {
            return ErrorResponse;
        }
    }
}
