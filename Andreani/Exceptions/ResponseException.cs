using Andreani.Models;

namespace Andreani.Exceptions
{
    public class ResponseException
    {
        protected ErrorResponse ErrorResponse;

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
