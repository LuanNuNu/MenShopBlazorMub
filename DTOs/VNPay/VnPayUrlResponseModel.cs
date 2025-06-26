namespace MenShopBlazor.DTOs.VNPay
{
    public class VnPayUrlResponseModel
    {
        public bool Success { get; set; }
        public string PaymentUrl { get; set; }
        public string Message { get; set; }
    }
}
