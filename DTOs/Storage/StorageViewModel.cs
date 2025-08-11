using MenShopBlazor.DTOs.Product.ViewModel;

namespace MenShopBlazor.DTOs.Storage
{
    public class StorageViewModel
    {
        public int StorageId { get; set; }
        public string? CategoryName { get; set; }
        public string? ManagerName { get; set; }
        public ICollection<ProductDetailViewModel>? StorageDetails { get; set; }
    }
}
