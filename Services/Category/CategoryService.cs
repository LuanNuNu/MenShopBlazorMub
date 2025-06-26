using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using System;
using Newtonsoft.Json;
using MenShopBlazor.DTOs.Category;
using MenShopBlazor.DTOs;
using MenShopBlazor.Services.Category;

namespace MenShopBlazor.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;
        private const string baseApiUrl = "http://localhost:5014/api/Category";

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<CategoryModelView>> GetAllCategoriesAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync(baseApiUrl);
                var content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<List<CategoryModelView>>(content)
                        ?? new List<CategoryModelView>();
                }

                Console.WriteLine($"Lỗi lấy danh sách danh mục: {response.StatusCode}");
                return new List<CategoryModelView>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi lấy danh sách danh mục: {ex.Message}");
                return new List<CategoryModelView>();
            }
        }

        public async Task<CategoryModelView?> GetCategoryByIdAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{baseApiUrl}/{id}");
                var content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<CategoryModelView>(content);
                }

                Console.WriteLine($"Lỗi lấy danh mục theo ID: {response.StatusCode}");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi lấy danh mục theo ID: {ex.Message}");
                return null;
            }
        }

        public async Task<CategoryModelView?> CreateCategoryAsync(CreateCategoryDTO category)
        {
            try
            {
                var json = JsonConvert.SerializeObject(category);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(baseApiUrl, content);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<CategoryModelView>(responseContent);
                }

                Console.WriteLine($"Lỗi tạo danh mục: {responseContent}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi tạo danh mục: {ex.Message}");
            }

            return null;
        }

        public async Task<CategoryModelView?> UpdateCategoryAsync(CategoryModelView category)
        {
            try
            {
                var json = JsonConvert.SerializeObject(category);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync($"{baseApiUrl}/{category.CategoryId}", content);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<CategoryModelView>(responseContent);
                }

                Console.WriteLine($"Lỗi cập nhật danh mục: {responseContent}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi cập nhật danh mục: {ex.Message}");
            }

            return null;
        }

        public async Task<ApiMessageReponse> DeleteCategoryAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{baseApiUrl}/{id}");
                var responseContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    return new ApiMessageReponse
                    {
                        Success = true,
                        Message = string.IsNullOrWhiteSpace(responseContent) ? "Xoá thành công." : responseContent
                    };
                }

                return new ApiMessageReponse
                {
                    Success = false,
                    Message = string.IsNullOrWhiteSpace(responseContent) ? "Đã xảy ra lỗi khi xoá danh mục." : responseContent
                };
            }
            catch (Exception ex)
            {
                return new ApiMessageReponse
                {
                    Success = false,
                    Message = $"Lỗi hệ thống: {ex.Message}"
                };
            }
        }
    }
}
