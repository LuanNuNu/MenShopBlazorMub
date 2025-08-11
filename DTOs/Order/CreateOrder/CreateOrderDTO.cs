using MenShopBlazor.DTOs.Order.CreateOrder;
using MenShopBlazor.Extensions;

namespace MenShopBlazor.DTOs.Order.CreateOrder
{
    public class CreateOrderDTO
    {
        public string? CustomerId { get; set; }
        public string? EmployeeId { get; set; }
        public string? ShipperId { get; set; }
        public decimal? ShippingFee { get; set; }
        public int? BranchId { get; set; }
        public bool IsOnline { get; set; }
        public string? Address { get; set; }
        public string? ReceiverName { get; set; }
        public string? ReceiverPhone { get; set; }
        public List<CreateOrderDetailDTO> Details { get; set; } = new();
    }

}
