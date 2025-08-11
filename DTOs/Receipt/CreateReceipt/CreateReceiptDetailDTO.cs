namespace MenShopBlazor.DTOs.Receipt.CreateReceipt
{
    public class CreateReceiptDetailDTO
    {
        public int? CategoryId { get; set; }
        public int? ProductId { get; set; }
        public int? ProfitPercent { get; set; }
        public int? ProductDetailId { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }
    }
}
