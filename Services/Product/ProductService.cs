using System.Net.Http;
using System.Text;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MenShopBlazor.DTOs.Product;
using MenShopBlazor.DTOs.Product.ViewModel;
using MenShopBlazor.DTOs;
using MenShopBlazor.DTOs.Product.ReponseDTO;
using MenShopBlazor.DTOs.Product.UpdateProduct;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text.Json;
using Newtonsoft.Json.Linq;
using MenShopBlazor.Shared;

namespace MenShopBlazor.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;
        private const string baseUrl = "https://localhost:7094/api/Product"; 

        public ProductService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("AuthorizedClient");
        }

        public async Task<IEnumerable<ProductViewModel>> GetAllProductsAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync(baseUrl);
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<ProductViewModel>>(json) ?? new();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi lấy danh sách sản phẩm: {ex.Message}");
                return new List<ProductViewModel>();
            }
        }
        public async Task<ProductViewModel?> GetProductByIdAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{baseUrl}/{id}");
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ProductViewModel>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi lấy sản phẩm theo ID: {ex.Message}");
                return null;
            }
        }
        public async Task<IEnumerable<ProductViewModel>> GetProductsByCategoryIdAsync(int categoryId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{baseUrl}/category/{categoryId}");
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<ProductViewModel>>(json) ?? new();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi lấy sản phẩm theo danh mục: {ex.Message}");
                return new List<ProductViewModel>();
            }
        }
        public async Task<IEnumerable<ProductDetailViewModel>> GetProductDetailsAsync(int productId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{baseUrl}/productDetails/{productId}");
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<ProductDetailViewModel>>(json) ?? new();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi lấy sản phẩm theo danh mục: {ex.Message}");
                return new List<ProductDetailViewModel>();
            }
        }
        //up1
        public async Task<IEnumerable<ImageProductViewModel>> GetImageProductDetailsAsync(int productDetailId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{baseUrl}/productDetails/images/{productDetailId}");
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<ImageProductViewModel>>(json) ?? new();
            }
            catch (Exception ex)
            {
                return new List<ImageProductViewModel>();
            }
        }
        public async Task<ProductResponseDTO?> CreateProductAsync(CreateProductDTO dto)
        {
            try
            {
                var json = JsonConvert.SerializeObject(dto);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync($"{baseUrl}/create", content);
                var result = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<ProductResponseDTO>(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi tạo sản phẩm: {ex.Message}");
                return new ProductResponseDTO { IsSuccess = false, Message = ex.Message };
            }
        }
        public async Task<CreateProductDetailResponse> AddProductDetailsAsync(AddProductDetailDTO dto)
        {
            try
            {
                var json = JsonConvert.SerializeObject(dto);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync($"{baseUrl}/add-detail", content);
                var result = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<CreateProductDetailResponse>(result)
                       ?? new CreateProductDetailResponse(); 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi thêm chi tiết sản phẩm: {ex.Message}");
                return new CreateProductDetailResponse
                {
                    Results = new List<ProductDetailResult>
            {
                new()
                {
                    IsSuccess = false,
                    Message = ex.Message
                }
            }
                };
            }
        }


        public async Task<List<CreateImageResponse>> AddImagesToDetailAsync(int detailId, List<string> imageUrls)
        {
            try
            {
                var json = JsonConvert.SerializeObject(imageUrls);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync($"{baseUrl}/add-images/{detailId}", content);
                var result = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<List<CreateImageResponse>>(result)
               ?? new List<CreateImageResponse>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi thêm ảnh chi tiết: {ex.Message}");
                return new List<CreateImageResponse>
                {
                    new CreateImageResponse { IsSuccess = false, Message = ex.Message }
                };
            }
        }

        public async Task<ProductResponseDTO?> UpdateProductAsync(int productId, UpdateProductDTO dto)
        {
            try
            {
                var json = JsonConvert.SerializeObject(dto);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync($"{baseUrl}/product/{productId}", content);
                var result = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<ProductResponseDTO>(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi cập nhật sản phẩm: {ex.Message}");
                return new ProductResponseDTO { IsSuccess = false, Message = ex.Message };
            }
        }
        public async Task<ProductDetailResponse> UpdateProductDetailAsync(UpdateProductDetailDTO dto)
        {
            try
            {
                var json = JsonConvert.SerializeObject(dto);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync($"{baseUrl}/product-detail", content);
                var result = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<ProductDetailResponse>(result)
                       ?? new ProductDetailResponse { IsSuccess = false };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi cập nhật chi tiết sản phẩm: {ex.Message}");
                return new ProductDetailResponse { IsSuccess = false, Message = ex.Message };
            }
        }
        public async Task<ImageResponse> UpdateProductDetailImagesAsync(int detailId, List<UpdateImageDTO> images)
        {
            try
            {
                var json = JsonConvert.SerializeObject(images);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync($"{baseUrl}/product-detail/{detailId}/images", content);
                var result = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<ImageResponse>(result)
                       ?? new ImageResponse { IsSuccess = false };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi cập nhật ảnh chi tiết sản phẩm: {ex.Message}");
                return new ImageResponse { IsSuccess = false, Message = ex.Message };
            }
        }


        public async Task<ApiResponseModel<object>> ToggleProductStatusAsync(int productId)
        {
            var emptyContent = new StringContent("", Encoding.UTF8, "application/json");

            return await HttpHelper.SendRequestAsync<object>(() =>
                _httpClient.PutAsync($"{baseUrl}/updateStatus/{productId}", emptyContent)
            );
        }

        public async Task<ApiResponseModel<object>> DeleteProductAsync(int productId)
        {
            return await HttpHelper.SendRequestAsync<object>(() =>
                _httpClient.DeleteAsync($"{baseUrl}/{productId}")
            );
        }

        public async Task<ApiResponseModel<object>> DeleteProductDetailAsync(int detailId)
        {
            return await HttpHelper.SendRequestAsync<object>(() =>
                _httpClient.DeleteAsync($"{baseUrl}/details/{detailId}")
            );
        }


        public async Task<ApiResponseModel<object>> DeleteImageProductDetailAsync(int imageId)
        {
            return await HttpHelper.SendRequestAsync<object>(() =>
                 _httpClient.DeleteAsync($"{baseUrl}/details/images/{imageId}")
            );
         
        }


    }
}
