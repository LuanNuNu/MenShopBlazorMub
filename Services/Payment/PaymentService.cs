using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MenShopBlazor.DTOs.Payment;
using MenShopBlazor.DTOs.VNPay;
using MenShopBlazor.DTOs.Order.OrderReponse;


namespace MenShopBlazor.Services.Payment
{
    public class PaymentService : IPaymentService
    {
        private readonly HttpClient _httpClient;
        private const string baseUrl = "http://localhost:7094/api/Payment";

        public PaymentService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("AuthorizedClient");
        }


        public async Task<string> CreateVNPayUrlAsync(VnPaymentRequestModel model)
        {
            var json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"{baseUrl}/create-vnpay-payment", content);
            var result = await response.Content.ReadAsStringAsync();

            var obj = JsonConvert.DeserializeObject<VnPayUrlResponseModel>(result);
            return obj?.PaymentUrl ?? "";
        }

        public async Task<PaymentResponseDTO> AddPaymentToOrderAsync(string orderId, CreatePaymentDTO dto)
        {
            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"{baseUrl}/api/payments/{orderId}", content);
            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<PaymentResponseDTO>(result);
        }

        public async Task<VnPaymentResponseModel> HandleVNPayCallbackAsync(string queryString)
        {
            var response = await _httpClient.GetAsync($"{baseUrl}/PaymentCallbackVnpay{queryString}");

            if (!response.IsSuccessStatusCode)
            {
                var raw = await response.Content.ReadAsStringAsync();
                throw new Exception($"Lỗi callback VNPay: {raw}");
            }

            var json = await response.Content.ReadAsStringAsync();

            try
            {
                var result = JsonConvert.DeserializeObject<VnPaymentResponseModel>(json);

                if (result == null || !result.Success)
                    throw new Exception("Kết quả callback VNPay không hợp lệ.");

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Không thể phân tích dữ liệu JSON từ VNPay: " + ex.Message);
            }
        }
    }
}
