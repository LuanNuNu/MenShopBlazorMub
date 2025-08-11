namespace MenShopBlazor.DTOs.Receipt.InputReceipt
{
    public class InputReceiptDetailDTO
    {
        public int DetailId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string ColorName { get; set; } = string.Empty;
        public string SizeName { get; set; } = string.Empty;
        public string FabricName { get; set; } = string.Empty;
        public decimal? InputPrice { get; set; }
        public int Quantity { get; set; }
    }
}
