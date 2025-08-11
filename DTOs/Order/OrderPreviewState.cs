using MenShopBlazor.Extensions;

namespace MenShopBlazor.DTOs.Order
{
    public class OrderPreviewState
    {
        public string OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus? Status { get; set; }
        public DateTime? PaidDate { get; set; }
        public string? Address { get; set; }
        public string? ReceiverName { get; set; }
        public string? ReceiverPhone { get; set; }
        public decimal? Subtotal { get; set; }
    }
}
