using System;
using Andreani.Models;

namespace Andreani.Exceptions
{
    public class ResponseException : Exception
    {
        protected ErrorResponse ErrorResponse;

        public ResponseException(string message) : base(message)
        {
        }

        public ResponseException(string message, ErrorResponse errorResponse) : base(message)
        {
            ErrorResponse = errorResponse;
        }

        public ErrorResponse GetErrorResponse()
        {
            return ErrorResponse;
        }
    }
}
