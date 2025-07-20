namespace MenShopBlazor.DTOs.Branch
{
    public class BranchProductDetailModel
    {
        public string? ProductName { get; set; }
        public List<string> Images { get; set; }
        public decimal? SellPrice { get; set; }
        public int? Quantity { get; set; }

        public string? ColorName { get; set; }
        public string? SizeName { get; set; }
        public string? FabricName { get; set; }
        public string? Description { get; set; }

    }
}
