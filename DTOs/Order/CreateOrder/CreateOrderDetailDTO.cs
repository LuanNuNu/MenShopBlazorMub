namespace MenShopBlazor.DTOs.Order.CreateOrder
{
    public class CreateOrderDetailDTO
    {
        public int ProductDetailId { get; set; }
        public int Quantity { get; set; }
        public decimal SellPrice { get; set; }
        public decimal? DiscountedPrice { get; set; }
    }

}
