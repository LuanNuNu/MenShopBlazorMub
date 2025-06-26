namespace MenShopBlazor.DTOs.Product.ReponseDTO
{
    public class CreateProductDetailResponse
    {
        public List<ProductDetailResult> Results { get; set; } = new();
    }

    public class ProductDetailResult
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;
        public ProductDetailItem Detail { get; set; } = new();
    }


    public class ProductDetailItem
    {
        public int ProductDetailId { get; set; }
        public int ProductId { get; set; }
        public int SizeId { get; set; }
        public int ColorId { get; set; }
        public int FabricId { get; set; }
    }
}
