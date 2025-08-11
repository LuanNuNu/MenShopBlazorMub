namespace MenShopBlazor.DTOs.Product.ViewModel
{
    public class ProductColorViewModel
    {
        public int ProductId { get; set; }
        public int? ProductDetailId { get; set; }
        public string? ProductName { get; set; }
        public int CategoryProductID { get; set; }
        public string? ColorName { get; set; }
        public string? Thumbnail { get; set; }
        public decimal? Price { get; set; }
        public decimal? DiscountPercent { get; set; }
        public decimal? SellPrice { get; set; }

        public bool IsFavorite { get; set; } = false;
    }
}
