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

namespace MenShopBlazor.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _http;
        private const string baseUrl = "http://localhost:5014/api/Product";

        public ProductService(HttpClient httpClient)
        {
            _http = httpClient;
        }

        public async Task<IEnumerable<ProductViewModel>> GetAllProductsAsync()
        {
            try
            {
                var response = await _http.GetAsync(baseUrl);
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
                var response = await _http.GetAsync($"{baseUrl}/{id}");
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
                var response = await _http.GetAsync($"{baseUrl}/Category/{categoryId}");
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
                var response = await _http.GetAsync($"{baseUrl}/productDetails/{productId}");
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
                var response = await _http.GetAsync($"{baseUrl}/productDetails/images/{productDetailId}");
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

                var response = await _http.PostAsync($"{baseUrl}/create", content);
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

                var response = await _http.PostAsync($"{baseUrl}/add-detail", content);
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

                var response = await _http.PostAsync($"{baseUrl}/add-images/{detailId}", content);
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

                var response = await _http.PutAsync($"{baseUrl}/product/{productId}", content);
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

                var response = await _http.PutAsync($"{baseUrl}/product-detail", content);
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

                var response = await _http.PutAsync($"{baseUrl}/product-detail/{detailId}/images", content);
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


        public async Task<ApiMessageReponse> ToggleProductStatusAsync(int productId)
        {
            var response = await _http.PutAsync($"{baseUrl}/updateStatus/{productId}", null);
            if (response.IsSuccessStatusCode)
            {
                return new ApiMessageReponse { Success = true, Message = "Cập nhật trạng thái thành công" };
            }
            return new ApiMessageReponse { Success = false, Message = "Cập nhật thất bại" };
        }
        public async Task<ApiMessageReponse> DeleteProductAsync(int productId)
        {
            var response = await _http.DeleteAsync($"{baseUrl}/{productId}");
            var content = await response.Content.ReadAsStringAsync();

            string userMessage;

            if (response.IsSuccessStatusCode)
            {
                userMessage = string.IsNullOrWhiteSpace(content)
                    ? "Xoá sản phẩm thành công."
                    : content;
            }
            else
            {
                try
                {
                    var obj = JsonConvert.DeserializeObject<JObject>(content);
                    userMessage = obj?["message"]?.ToString()
                                  ?? "Không thể xoá sản phẩm do có lỗi phát sinh.";
                }
                catch
                {
                    userMessage = "Không thể xoá sản phẩm do có lỗi phát sinh.";
                }
            }

            return new ApiMessageReponse
            {
                Success = response.IsSuccessStatusCode,
                Message = userMessage
            };
        }
        public async Task<ApiMessageReponse> DeleteProductDetailAsync(int detailId)
        {
            var response = await _http.DeleteAsync($"{baseUrl}/details/{detailId}");
            var content = await response.Content.ReadAsStringAsync();

            string userMessage;

            if (response.IsSuccessStatusCode)
            {
                userMessage = string.IsNullOrWhiteSpace(content)
                    ? "Xoá chi tiết sản phẩm thành công."
                    : content;
            }
            else
            {
                try
                {
                    var obj = JsonConvert.DeserializeObject<JObject>(content);
                    userMessage = obj?["message"]?.ToString()
                                  ?? "Không thể xoá chi tiết sản phẩm do có lỗi phát sinh.";
                }
                catch
                {
                    userMessage = "Không thể xoá chi tiết sản phẩm do có lỗi phát sinh.";
                }
            }

            return new ApiMessageReponse
            {
                Success = response.IsSuccessStatusCode,
                Message = userMessage
            };
        }


        //up
        public async Task<ApiMessageReponse> DeleteImageProductDetailAsync(int imageId)
        {
            var response = await _http.DeleteAsync($"{baseUrl}/details/images/{imageId}");
            var message = await response.Content.ReadAsStringAsync();

            return new ApiMessageReponse
            {
                Success = response.IsSuccessStatusCode,
                Message = string.IsNullOrWhiteSpace(message)
                    ? (response.IsSuccessStatusCode ? "Xoá ảnh chi tiết sản phẩm thành công." : "Lỗi khi xoá ảnh chi tiết.")
                    : message
            };
        }
    }
}
