namespace MenShopBlazor.DTOs.Product
{
    public class AddProductDetailDTO
    {
        public int ProductId { get; set; }
        public List<ProductDetailItemDTO> Details { get; set; }
    }
}
