namespace MenShopBlazor.DTOs.DiscountPrice
{
    public class DiscountPriceDetailResponsenew
    {
        public int Id { get; set; }
        public int discountPriceId { get; set; }
        public int productDetailId { get; set; }

        public string ProductName { get; set; }
        public string ColorName { get; set; }
        public string SizeName { get; set; }
        public string FabricName { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
