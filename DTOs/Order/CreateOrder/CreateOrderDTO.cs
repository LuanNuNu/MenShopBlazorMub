using MenShopBlazor.DTOs.Order.CreateOrder;
using MenShopBlazor.Extensions;

namespace MenShopBlazor.DTOs.Order.CreateOrder
{
    public class CreateOrderDTO
    {
        public string? CustomerId { get; set; }
        public string? EmployeeId { get; set; }
        public string? ShipperId { get; set; }
        public bool IsOnline { get; set; }
        public List<CreateOrderDetailDTO> Details { get; set; } = new();
    }

}
