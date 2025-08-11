using MenShopBlazor.DTOs.Product.ViewModel;
using MenShopBlazor.Extensions;

namespace MenShopBlazor.DTOs.Receipt.OutputReceipt
{
    public class OutputReceiptDTO
    {
        public int ReceiptId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? CancelDate { get; set; }
        public DateTime? ConfirmedDate { get; set; }
        public OrderStatus? Status { get; set; }
        public decimal? Total { get; set; }
        public string? ManagerName { get; set; }
        public string? BranchName { get; set; }
        public ICollection<ProductDetailViewModel>? OutputReceiptDetails { get; set; }
    }
}
