namespace MenShopBlazor.DTOs.Product.ViewModel
{
    public class ProductColorViewModel
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public int CategoryProductID { get; set; }
        public string? ColorName { get; set; }
        public string? Thumbnail { get; set; }
        public decimal? Price { get; set; }
    }
}
