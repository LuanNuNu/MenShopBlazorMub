namespace MenShopBlazor.DTOs.Statistic
{
    public class TopBestSellingProductDto
    {
        public int ProductId { get; set; }
        public int ProductDetailId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int TotalQuantity { get; set; }
    }
}
