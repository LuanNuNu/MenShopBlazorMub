namespace MenShopBlazor.DTOs.DiscountPrice
{
    public class CreateDiscountPriceDetailDTO
    {
        public int discountPriceId { get; set; }
        public List<int> productDetailIds { get; set; }
    }
}
