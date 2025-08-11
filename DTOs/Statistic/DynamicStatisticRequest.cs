using MenShopBlazor.Extensions;

namespace MenShopBlazor.DTOs.Statistic
{
    public class DynamicStatisticRequest
    {
        public StatisticMode Mode { get; set; }
        public int? Year { get; set; }         
        public int? Month { get; set; }        
        public int? BranchId { get; set; }
    }
}
