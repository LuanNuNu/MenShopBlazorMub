using MenShopBlazor.DTOs;
using MenShopBlazor.DTOs.Order;
using MenShopBlazor.DTOs.Order.CreateOrder;
using MenShopBlazor.DTOs.Order.OrderReponse;
using MenShopBlazor.DTOs.Product.ViewModel;
using MenShopBlazor.Shared;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace MenShopBlazor.Services.Order
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _httpClient;
        private const string baseUrl = "https://localhost:7094/api/Order";

        public OrderService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("AuthorizedClient");
        }
        public async Task<OrderResponseDTO> CreateOrderAsync(CreateOrderDTO dto)
        {
            try
            {
                var json = JsonConvert.SerializeObject(dto);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync($"{baseUrl}/createOrder", content);
                var result = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<OrderResponseDTO>(result);
            }
            catch (Exception ex)
            {
                return new OrderResponseDTO { IsSuccess = false, Message = ex.Message };
            }
        }

        public async Task<OrderViewModel?> GetOrderByIdAsync(string orderId)
        {
            var response = await _httpClient.GetAsync($"{baseUrl}/get-ordersId/{orderId}");
            if (!response.IsSuccessStatusCode) return null;

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<OrderViewModel>(content);
        }

        public async Task<List<OrderViewModel>?> GetAllOrdersAsync()
        {
            var response = await _httpClient.GetAsync($"{baseUrl}/getall-orders");
            if (!response.IsSuccessStatusCode) return null;

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<OrderViewModel>>(content);
        }
        public async Task<List<OrderViewModel>?> GetAllOnlineOrdersAsync()
        {
            var response = await _httpClient.GetAsync($"{baseUrl}/getall-onlineorders");
            if (!response.IsSuccessStatusCode) return null;

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<OrderViewModel>>(content);
        }

        public async Task<List<OrderViewModel>?> GetOrdersByCustomerIdAsync(string customerId)
        {
            var response = await _httpClient.GetAsync($"{baseUrl}/get-order-by-customerId?customerId={customerId}");
            if (!response.IsSuccessStatusCode) return null;

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<OrderViewModel>>(content);
        }

        public async Task<List<OrderProductDetailViewModel>> GetOrderDetailAsync(string orderId)
        {
            var response = await _httpClient.GetAsync($"{baseUrl}/get-order-detail/{orderId}");
            if (!response.IsSuccessStatusCode) return null;

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<OrderProductDetailViewModel>>(content);
        }


        public async Task<List<OrderViewModel>?> SearchOrdersAsync(SearchOrderDTO search)
        {
            var json = JsonConvert.SerializeObject(search);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"{baseUrl}/search", content);
            if (!response.IsSuccessStatusCode) return null;

            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<OrderViewModel>>(result);
        }
        public async Task<ApprovalResultDTO?> AutoApproveOrderAsync(string orderId)
        {
            var response = await _httpClient.PutAsync($"{baseUrl}/auto-approve/{orderId}", null);
            if (!response.IsSuccessStatusCode)
                return null;

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ApprovalResultDTO>(content);
        }

        public async Task<ApprovalResultDTO?> AutoDecreaseStockOffline(string orderId)
        {
            var response = await _httpClient.PutAsync($"{baseUrl}/auto-decrease-stock/{orderId}", null);
            if (!response.IsSuccessStatusCode)
                return null;

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ApprovalResultDTO>(content);
        }



        public async Task<List<OrderViewModel>?> GetPendingOrdersAsync()
        {
            var response = await _httpClient.GetAsync($"{baseUrl}/pending");
            if (!response.IsSuccessStatusCode) return null;

            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<OrderViewModel>>(result);
        }

        public async Task<ApiResponseModel<List<OrderViewModel>>> GetOrdersByDistrictAsync(string district)
        {
            return await HttpHelper.SendRequestAsync<List<OrderViewModel>>(() =>
                _httpClient.GetAsync($"{baseUrl}/getorders-by-district?district={district}")
            );
        }


        public async Task<ApiResponseModel<object>> UpdateOrderShipperStatusAsync(string orderId, string shipperId)
        {
            return await HttpHelper.SendRequestAsync<object>(() =>
                _httpClient.PutAsync($"{baseUrl}/updateOrder-shipperStatus?orderId={orderId}&shipperId={shipperId}", null)
            );
        }

        public async Task<ApiResponseModel<object>> CompleteOrderAsync(string orderId)
        {
            return await HttpHelper.SendRequestAsync<object>(() =>
                _httpClient.PutAsync($"{baseUrl}/complete/{orderId}", null)
            );
        }

        public async Task<ApiResponseModel<object>> CancelOrderAsync(string orderId, string reason)
        {
            var encodedReason = Uri.EscapeDataString(reason); 
            var url = $"{baseUrl}/cancel/{orderId}?reason={encodedReason}";

            return await HttpHelper.SendRequestAsync<object>(() =>
                _httpClient.PutAsync(url, null)
            );
        }



        public async Task<List<OrderViewModel>?> GetOrdersByShipperIdAsync(string shipperId)
        {
            var response = await _httpClient.GetAsync($"{baseUrl}/get-orders/{shipperId}");
            if (!response.IsSuccessStatusCode) return null;

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<OrderViewModel>>(content);
        }
    }
}
