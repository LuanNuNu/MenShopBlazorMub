namespace MenShopBlazor.DTOs.VNPay
{
    public class VnPaymentRequestModel
    {
        public string OrderId { get; set; }
        public string FullName { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
    }
}
