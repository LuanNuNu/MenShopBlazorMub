using MenShopBlazor.DTOs.Statistic;
using MenShopBlazor.Extensions;

namespace MenShopBlazor.Services.Statistic
{
    public interface IStatisticService
    {
        Task<List<DynamicStatisticItem>> GetDynamicStatisticsAsync(StatisticMode mode, int? year = null, int? month = null, int? branchId = null);
        Task<List<TopProductDto>> GetTopProductsAsync(int top = 10);
        Task<List<TopCustomerDto>> GetTopCustomersAsync(int top = 10);
        Task<List<TopBestSellingProductDto>> GetTopBestSellingProductsByDayAsync(DateTime? date = null, int top = 10, int? branchId = null);
        Task<int> GetTotalOrdersByDayAsync(DateTime? date = null, int? branchId = null);
    }
}
