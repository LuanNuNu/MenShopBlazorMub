using MenShopBlazor.DTOs.Product.ReponseDTO;
using MenShopBlazor.DTOs.Order.CreateOrder;
using MenShopBlazor.DTOs.Order.OrderReponse;
using Newtonsoft.Json;
using System.Text;

namespace MenShopBlazor.Services.Order
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _http;
        private const string baseUrl = "http://localhost:5014/api/Order";

        public OrderService(HttpClient httpClient)
        {
            _http = httpClient;
        }
        public async Task<OrderResponseDTO> CreateOrderAsync(CreateOrderDTO dto)
        {
            try
            {
                var json = JsonConvert.SerializeObject(dto);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _http.PostAsync($"{baseUrl}/createOrder", content);
                var result = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<OrderResponseDTO>(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi tạo sản phẩm: {ex.Message}");
                return new OrderResponseDTO { IsSuccess = false, Message = ex.Message };
            }
        }
    }
}
