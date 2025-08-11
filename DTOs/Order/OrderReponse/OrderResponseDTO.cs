using MenShopBlazor.DTOs.Order.OrderReponse;
using MenShopBlazor.Extensions;

namespace MenShopBlazor.DTOs.Order.OrderReponse
{
    public class OrderResponseDTO
    {
        public string OrderId { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
