using MenShopBlazor.DTOs;
using Newtonsoft.Json;

namespace MenShopBlazor.Shared
{
    public static class HttpHelper
    {
        public static async Task<ApiResponseModel<T>> SendRequestAsync<T>(
    Func<Task<HttpResponseMessage>> httpCall)
        {
            try
            {
                var response = await httpCall();
                var responseContent = await response.Content.ReadAsStringAsync();

                if (string.IsNullOrWhiteSpace(responseContent))
                {
                    return new ApiResponseModel<T>(
                        response.IsSuccessStatusCode,
                        response.IsSuccessStatusCode ? "Thành công." : "Thất bại.",
                        default,
                        (int)response.StatusCode
                    );
                }

                ApiResponseModel<T>? result = null;
                try
                {
                    result = JsonConvert.DeserializeObject<ApiResponseModel<T>>(responseContent);
                }
                catch
                {
                    // Nếu parse fail, coi như message text thuần
                    return new ApiResponseModel<T>(
                        response.IsSuccessStatusCode,
                        responseContent,
                        default,
                        (int)response.StatusCode
                    );
                }

                if (result == null)
                {
                    return new ApiResponseModel<T>(
                        false,
                        "Phản hồi không hợp lệ từ API.",
                        default,
                        (int)response.StatusCode
                    );
                }

                return result;
            }
            catch (Exception ex)
            {
                return new ApiResponseModel<T>(
                    false,
                    $"Lỗi hệ thống: {ex.Message}",
                    default,
                    500
                );
            }
        }

    }

}
