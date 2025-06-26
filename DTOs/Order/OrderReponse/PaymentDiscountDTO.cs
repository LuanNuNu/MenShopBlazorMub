using MenShopBlazor.Extensions;

namespace MenShopBlazor.DTOs.Order.OrderReponse
{
    public class PaymentDiscountDTO
    {
        public string? CouponCode { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal DiscountPercentage { get; set; }
        public DiscountType Type { get; set; }
    }

}
