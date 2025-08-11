namespace MenShopBlazor.DTOs.Order
{
    public class ApprovalResultDTO
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public string? OrderId { get; set; }
    }
}
