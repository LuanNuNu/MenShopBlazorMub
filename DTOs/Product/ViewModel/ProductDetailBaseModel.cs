namespace MenShopBlazor.DTOs.Product.ViewModel
{
    public class ProductDetailBaseModel
    {
        public int DetailId { get; set; }
        public string? ProductName { get; set; }
        public string? SizeName { get; set; }
        public string? ColorName { get; set; }
        public string? FabricName { get; set; }
        public decimal? SellPrice { get; set; }
        public decimal? DiscountedPrice { get; set; }
        public int? Quantity { get; set; }
        public ICollection<string>? Images { get; set; }
    }
}
