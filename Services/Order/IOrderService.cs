using MenShopBlazor.DTOs.Order.CreateOrder;
using MenShopBlazor.DTOs.Order.OrderReponse;

namespace MenShopBlazor.Services.Order
{
    public interface IOrderService
    {
        Task<OrderResponseDTO> CreateOrderAsync(CreateOrderDTO createProductDTO);
    }
}
