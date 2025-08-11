namespace MenShopBlazor.DTOs.Product.ViewModel
{
    public class ProductDetailViewModel : ProductDetailBaseModel
    {
        public decimal? InputPrice { get; set; }
        public decimal? DiscountPercent { get; set; }
        public DateTime? LatestPriceDate { get; set; }
    }
}
