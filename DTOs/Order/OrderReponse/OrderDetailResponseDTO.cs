using MenShopBlazor.DTOs.Order.OrderReponse;

namespace MenShopBlazor.DTOs.Order.OrderReponse
{
    public class OrderDetailResponseDTO
    {
        public int ProductDetailId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        //public ProductDetailDto ProductDetail { get; set; }
    }

}
