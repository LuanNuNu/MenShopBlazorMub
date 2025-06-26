namespace MenShopBlazor.DTOs.Product.ReponseDTO
{
    public class ProductDetailResponse
    {
        public int ProductDetailId { get; set; }
        public int SizeId { get; set; }
        public int ColorId { get; set; }
        public int FabricId { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }

}
