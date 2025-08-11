namespace MenShopBlazor.DTOs.DiscountPrice
{
    public class DiscountPriceResponse
    {
        public string Name { get; set; }
        public decimal DiscountPercent { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
