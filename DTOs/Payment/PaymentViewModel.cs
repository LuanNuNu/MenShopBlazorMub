using MenShopBlazor.Extensions;

namespace MenShopBlazor.DTOs.Payment
{
    public class PaymentViewModel
    {
        public string? PaymentId { get; set; }
        public string? OrderId { get; set; }
        public decimal Amount { get; set; }
        public DateTime? PaymentDate { get; set; }
        public PaymentMethod? Method { get; set; }
        public PaymentStatus? Status { get; set; }
        public string? TransactionCode { get; set; }
        public string? PaymentProvider { get; set; }
        public string? Notes { get; set; }
        public string? StaffId { get; set; }
        public List<PaymentDiscountViewModel>? Discounts { get; set; } = new();
    }
}
