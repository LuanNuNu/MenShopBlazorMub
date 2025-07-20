using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using System;
using Newtonsoft.Json;
using MenShopBlazor.DTOs.Category;
using MenShopBlazor.DTOs;
using MenShopBlazor.Services.Category;
using MenShopBlazor.Shared;

namespace MenShopBlazor.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;
        private const string baseApiUrl = "https://localhost:7094/api/CategoryProduct";

        public CategoryService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("AuthorizedClient");
        }

        public async Task<IEnumerable<CategoryProductViewModel>> GetAllCategoriesAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync(baseApiUrl);
                var content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = JsonConvert.DeserializeObject<ApiResponseModel<List<CategoryProductViewModel>>>(content);
                    if (apiResponse != null && apiResponse.IsSuccess && apiResponse.Data != null)
                    {
                        return apiResponse.Data;
                    }
                }

                Console.WriteLine($"Lỗi lấy danh sách danh mục: {content}");
                return new List<CategoryProductViewModel>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi lấy danh sách danh mục: {ex.Message}");
                return new List<CategoryProductViewModel>();
            }
        }

        public async Task<CategoryProductViewModel?> GetCategoryByIdAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{baseApiUrl}/{id}");
                var content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = JsonConvert.DeserializeObject<ApiResponseModel<CategoryProductViewModel>>(content);
                    if (apiResponse != null && apiResponse.IsSuccess)
                    {
                        return apiResponse.Data;
                    }
                }

                Console.WriteLine($"Lỗi lấy danh mục theo ID: {content}");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi lấy danh mục theo ID: {ex.Message}");
                return null;
            }
        }

        public async Task<ApiResponseModel<object>> CreateCategoryAsync(CreateUpdateCategoryDTO category)
        {
            var json = JsonConvert.SerializeObject(category);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            return await HttpHelper.SendRequestAsync<object>(() =>
                _httpClient.PostAsync(baseApiUrl, content)
            );
        }


        public async Task<ApiResponseModel<object>> UpdateCategoryAsync(int categoryId,CreateUpdateCategoryDTO category)
        {
            var json = JsonConvert.SerializeObject(category);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            return await HttpHelper.SendRequestAsync<object>(() =>
                _httpClient.PutAsync($"{baseApiUrl}/{categoryId}", content)
            );
        }

        public async Task<ApiResponseModel<object>> DeleteCategoryAsync(int id)
        {
            return await HttpHelper.SendRequestAsync<object>(() =>
                _httpClient.DeleteAsync($"{baseApiUrl}/{id}")
            );
        }

    }
}

