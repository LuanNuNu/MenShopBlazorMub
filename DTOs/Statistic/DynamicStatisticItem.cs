namespace MenShopBlazor.DTOs.Statistic
{
    public class DynamicStatisticItem
    {
        public string Label { get; set; } = null!;
        public decimal Revenue { get; set; }
        public int OrderCount { get; set; }
        public int ProductSold { get; set; }
    }
}
