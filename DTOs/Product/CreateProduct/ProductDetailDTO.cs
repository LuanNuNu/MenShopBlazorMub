namespace MenShopBlazor.DTOs.Product
{
    public class ProductDetailDTO
    {
        public int DetailId { get; set; }
        public int SizeId { get; set; }
        public int ColorId { get; set; }
        public int FabricId { get; set; }

        public List<ImageDTO> Images { get; set; }
    }

}
