namespace Microservices.Shared
{
    public class ApiResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public ApiResponse()
        {
            
        }
        protected ApiResponse(bool isSuccess, string message, int statusCode) 
        {
            IsSuccess = isSuccess;  
            Message = message;
            StatusCode = statusCode;
        }
    }

    public class ApiResponse<T> : ApiResponse
    {
        public T Data { get; set; }
        public ApiResponse()
        {
            
        }

        private ApiResponse(bool isSuccess, T data, string errorMessage, int statusCode) : base(isSuccess, errorMessage, statusCode) 
        { 
            Data = data;
        }
        public static ApiResponse<T> Success(T data) => new ApiResponse<T>(true, data, "Success", 200);
        public static ApiResponse<T> Failure(string errorMessage, int statusCode = 500) => new ApiResponse<T>(false, default, errorMessage, statusCode);
    }
}
