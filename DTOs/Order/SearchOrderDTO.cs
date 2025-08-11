using MenShopBlazor.Extensions;

namespace MenShopBlazor.DTOs.Order
{
    public class SearchOrderDTO
    {
        public string? CustomerId { get; set; }
        public OrderStatus? Status { get; set; }
        public string? OrderId { get; set; }
        public string? ShipperId { get; set; }
        public string? BranchId { get; set; }
        public bool? IsOnline { get; set; }
        public string? Province { get; set; }
        public string? District { get; set; }
        public string? Ward { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
