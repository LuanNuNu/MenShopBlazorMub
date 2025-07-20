namespace MenShopBlazor.DTOs
{
    public class ApiResponseModel<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public T? Data { get; set; }
        public int StatusCode { get; set; }
        public List<string>? Errors { get; set; }
        public ApiResponseModel(bool isSuccess, string message, T? data, int statusCode, List<string>? errors = null)
        {
            IsSuccess = isSuccess;
            Message = message;
            Data = data;
            StatusCode = statusCode;
            Errors = errors;
        }
    }
}
