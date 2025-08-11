using System.Text.Json;

namespace MenShopBlazor.DTOs.Account
{
    public class ApiResponse<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
