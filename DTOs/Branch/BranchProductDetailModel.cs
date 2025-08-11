namespace MenShopBlazor.DTOs.Branch
{
    public class BranchProductDetailModel
    {
        public int? DetailId { get; set; }
        public int? ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? Product { get; set; }
        public List<string> Images { get; set; }
        public int? Quantity { get; set; }
        public decimal? SellPrice { get; set; }
        public decimal? DiscountPercent { get; set; }
        public decimal? DiscountedPrice { get; set; }
        public string? ColorName { get; set; }
        public string? SizeName { get; set; }
        public string? FabricName { get; set; }
        public string? Description { get; set; }

        public bool IsFavorite { get; set; } = false;

    }
}
