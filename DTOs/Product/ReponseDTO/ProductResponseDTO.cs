namespace MenShopBlazor.DTOs.Product.ReponseDTO
{
    public class ProductResponseDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public bool Status { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
