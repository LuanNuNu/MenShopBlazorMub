namespace MenShopBlazor.DTOs.Product.ViewModel
{
    public class ProductDetailViewModel
    {
        public int DetailId { get; set; }
        public int ProductId { get; set; }
        public string SizeName { get; set; }
        public string ColorName { get; set; }
        public string FabricName { get; set; }
       
        public List<HistoryPriceViewModel> HistoryPrices { get; set; }
        public List<ImageProductViewModel> Images { get; set; }

    }
}
