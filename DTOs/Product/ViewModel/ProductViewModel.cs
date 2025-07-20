namespace MenShopBlazor.DTOs.Product.ViewModel
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public int? CategoryProductID { get; set; }
        public string? CategoryName { get; set; }
        public decimal? Price { get; set; }//
        public bool Status { get; set; }
        public string? Thumbnail { get; set; }
        public ICollection<ProductDetailViewModel>? ProductDetails { get; set; }
    }
}
