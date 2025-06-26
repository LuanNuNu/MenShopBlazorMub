namespace MenShopBlazor.DTOs.Product.ViewModel
{
    public class HistoryPriceViewModel
    {
        public decimal InputPrice { get; set; }
        public decimal OnlinePrice { get; set; }
        public decimal OfflinePrice { get; set; }
        public decimal SellPrice { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
