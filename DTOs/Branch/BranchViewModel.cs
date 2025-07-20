using MenShopBlazor.DTOs.Product.ViewModel;

namespace MenShopBlazor.DTOs.Branch
{
    public class BranchViewModel
    {
        public int BranchId { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? ManagerName { get; set; }
        public bool IsOnline { get; set; }
        public ICollection<ProductDetailViewModel>? BranchDetails { get; set; }
    }
}
