using MenShopBlazor.Extensions;
using MenShopBlazor.DTOs.Order.OrderReponse;

namespace MenShopBlazor.DTOs.Order.OrderReponse
{
    public class PaymentResponseDTO
    {
        public string PaymentId { get; set; }
        public decimal Amount { get; set; }
        public DateTime? PaymentDate { get; set; }
        public PaymentMethod Method { get; set; }
        public PaymentStatus Status { get; set; }
        public string? TransactionCode { get; set; }
        public string? PaymentProvider { get; set; }
        public string? Notes { get; set; }

        public string? StaffId { get; set; }
        public List<PaymentDiscountDTO>? Discounts { get; set; } = new();
    }

}
