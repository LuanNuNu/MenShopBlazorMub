namespace MenShopBlazor.DTOs.DiscountPrice
{
    public class DiscountPriceDetailResponse
    {
        public List<ProductResult> Results { get; set; } = new();
    }
    public class ProductResult
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
