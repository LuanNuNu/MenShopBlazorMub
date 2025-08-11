namespace MenShopBlazor.DTOs.Cart
{
    public class CartActionDTO
    {
        public string? CustomerId { get; set; }
        public string? AnonymousId { get; set; }
        public int ProductDetailId { get; set; }
        public int Quantity { get; set; } = 1;
    }
}
