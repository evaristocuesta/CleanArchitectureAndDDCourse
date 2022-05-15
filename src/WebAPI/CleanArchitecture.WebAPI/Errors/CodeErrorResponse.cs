namespace CleanArchitecture.WebAPI.Errors
{
    public class CodeErrorResponse
    {
        public CodeErrorResponse(int statusCode, string? message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageStatusCode(statusCode);
        }

        public int StatusCode { get; set; }
        public string? Message { get; set; }

        private string GetDefaultMessageStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "Request sended has errors",
                401 => "Authorization required",
                404 => "Resource not found",
                500 => "Internal server error",
                _ => string.Empty
            };
        }
    }
}
