namespace MenShopBlazor.DTOs.Branch
{
    public class BranchProductModel
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public int CategoryProductID { get; set; }
        public string? Description { get; set; }
        public string? Thumbnail { get; set; }
        public decimal? Price { get; set; } 
    }

}
