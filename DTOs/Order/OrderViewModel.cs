using MenShopBlazor.DTOs.Product.ViewModel;
using MenShopBlazor.DTOs.Payment;
using MenShopBlazor.Extensions;

namespace MenShopBlazor.DTOs.Order
{
    public class OrderViewModel
    {
        public string OrderId { get; set; }
        public string? CustomerName { get; set; }
        public string? EmployeeName { get; set; }
        public string? ShipperName { get; set; }
        public string? ShipperId { get; set; }
        public string? BranchName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public DateTime? PaidDate { get; set; }
        public OrderStatus? Status { get; set; }
        public string? IsOnline { get; set; }

        public string? Address { get; set; }
        public string? ReceiverName { get; set; }
        public string? ReceiverPhone { get; set; }
        public decimal? Subtotal { get; set; }

        public decimal? ShippingFee { get; set; }
        public decimal? Total => (Subtotal ?? 0) + (ShippingFee ?? 0);
        public int? BranchId { get; set; }
        //public List<ProductDetailViewModel>? Details { get; set; }
        public List<PaymentViewModel>? Payments { get; set; }
    }
}
