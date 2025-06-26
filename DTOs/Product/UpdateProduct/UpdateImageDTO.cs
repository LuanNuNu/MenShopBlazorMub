namespace MenShopBlazor.DTOs.Product.UpdateProduct
{
    public class UpdateImageDTO
    {
        public int ImageId { get; set; }
        public int ProductDetailId { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
    }
}
