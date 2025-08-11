using MenShopBlazor.DTOs;
using MenShopBlazor.DTOs.Statistic;
using MenShopBlazor.Shared;
using MenShopBlazor.Extensions;
namespace MenShopBlazor.Services.Statistic
{
    public class StatisticService : IStatisticService
    {
        private readonly HttpClient _httpClient;
        private readonly string baseUrl = "https://localhost:7094/api/Statistic";

        public StatisticService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("AuthorizedClient");
        }

        public async Task<List<DynamicStatisticItem>> GetDynamicStatisticsAsync(StatisticMode mode, int? year = null, int? month = null, int? branchId = null)
        {
            var queryParams = new List<string> { $"mode={mode}" };
            if (year.HasValue) queryParams.Add($"year={year.Value}");
            if (month.HasValue) queryParams.Add($"month={month.Value}");
            if (branchId.HasValue) queryParams.Add($"branchId={branchId.Value}");

            var url = $"{baseUrl}/dynamic";
            if (queryParams.Count > 0)
                url += "?" + string.Join("&", queryParams);

            var response = await HttpHelper.SendRequestAsync<List<DynamicStatisticItem>>(() =>
                _httpClient.GetAsync(url)
            );

            if (response.IsSuccess && response.Data != null)
                return response.Data;

            return new List<DynamicStatisticItem>();
        }

        public async Task<List<TopProductDto>> GetTopProductsAsync(int top = 10)
        {
            var url = $"{baseUrl}/top-products?top={top}";
            var response = await HttpHelper.SendRequestAsync<List<TopProductDto>>(() =>
                _httpClient.GetAsync(url)
            );

            if (response.IsSuccess && response.Data != null)
                return response.Data;

            return new List<TopProductDto>();
        }


        public async Task<List<TopCustomerDto>> GetTopCustomersAsync(int top = 10)
        {
            var url = $"{baseUrl}/top-customers?top={top}";
            var response = await HttpHelper.SendRequestAsync<List<TopCustomerDto>>(() =>
                _httpClient.GetAsync(url)
            );

            if (response.IsSuccess && response.Data != null)
                return response.Data;

            return new List<TopCustomerDto>();
        }

        public async Task<List<TopBestSellingProductDto>> GetTopBestSellingProductsByDayAsync(DateTime? date = null, int top = 10, int? branchId = null)
        {
            var url = $"{baseUrl}/top-best-selling-products-by-day?";

            if (date.HasValue)
                url += $"date={date.Value:yyyy-MM-dd}&";

            url += $"top={top}&";

            if (branchId.HasValue)
                url += $"branchId={branchId.Value}";

            var response = await HttpHelper.SendRequestAsync<List<TopBestSellingProductDto>>(() =>
                _httpClient.GetAsync(url)
            );

            if (response.IsSuccess && response.Data != null)
                return response.Data;

            return new List<TopBestSellingProductDto>();
        }

        public async Task<int> GetTotalOrdersByDayAsync(DateTime? date = null, int? branchId = null)
        {
            var url = $"{baseUrl}/total-orders-by-day?";

            if (date.HasValue)
                url += $"date={date.Value:yyyy-MM-dd}&";

            if (branchId.HasValue)
                url += $"branchId={branchId.Value}";

            var response = await HttpHelper.SendRequestAsync<int>(() =>
                _httpClient.GetAsync(url)
            );

            if (response.IsSuccess)
                return response.Data;

            return 0;
        }

    }

}
