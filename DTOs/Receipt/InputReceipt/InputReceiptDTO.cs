using MenShopBlazor.DTOs.Product.ViewModel;
using MenShopBlazor.Extensions;

namespace MenShopBlazor.DTOs.Receipt.InputReceipt
{
    public class InputReceiptDTO
    {
        public int ReceiptId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? CancelDate { get; set; }
        public DateTime? ConfirmedDate { get; set; }
        public OrderStatus? Status { get; set; }
        public decimal? Total { get; set; }
        public string? ManagerName { get; set; }
        public string? StorageName { get; set; }
        public ICollection<ProductDetailViewModel>? InputReceiptDetails { get; set; }
    }
}
