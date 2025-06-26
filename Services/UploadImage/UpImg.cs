using Newtonsoft.Json;
using static System.Net.WebRequestMethods;

namespace MenShopBlazor.Services.UploadImage
{
    public class UpImg : IUpImg
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl = "http://localhost:5014/api/UploadImage";

        public UpImg(HttpClient httpClient)
        {
            _httpClient = httpClient;

        }

        public async Task<string> UploadImage(MultipartFormDataContent content)
        {
            var postResult = await _httpClient.PostAsync(_apiBaseUrl, content);
            var postContent = await postResult.Content.ReadAsStringAsync();

            if (!postResult.IsSuccessStatusCode)
            {
                throw new ApplicationException(postContent);
            }
            else
            {

                var jsonResponse = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(postContent);

                if (jsonResponse != null && jsonResponse.TryGetValue("filePaths", out var filePaths) && filePaths.Any())
                {
                    var filePath = filePaths.First(); 
                    var imgUrl = $"http://localhost:5014/{filePath.Replace("\\", "/")}";
                    return imgUrl;
                }
                else
                {
                    throw new ApplicationException("Không tìm thấy filePaths trong phản hồi từ server.");
                }
            }
        }

    }
}
