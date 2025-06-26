using MenShopBlazor.Extensions;

namespace MenShopBlazor.DTOs.Payment
{
    public class CreatePaymentDiscountDTO
    {
        public string CouponCode { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal DiscountPercentage { get; set; }
        public DiscountType Type { get; set; }

    }
}
