namespace MenShopBlazor.DTOs.Receipt.InputReceipt
{
    public class InputReceiptProductViewModel
    {
        public int DetailId { get; set; }
        public string? ProductName { get; set; }
        public string? SizeName { get; set; }
        public string? ColorName { get; set; }
        public string? FabricName { get; set; }
        public int? Quantity { get; set; }
        public decimal? InputPrice { get; set; }
    }
}
