namespace MenShopBlazor.DTOs.DiscountPrice
{
    public class DiscountPriceDetailViewModel
    {
        public int Id { get; set; }
        public int discountPriceId { get; set; }
        public int productDetailId { get; set; }

        public string ProductName { get; set; }
        public string ColorName { get; set; }
        public string SizeName { get; set; }
        public string FabricName { get; set; }
    }
}
