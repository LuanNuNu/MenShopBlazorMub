using MenShopBlazor.DTOs.Product.ViewModel;

namespace MenShopBlazor.DTOs.Storage
{
    public class StorageDTO
    {
        public int StorageId { get; set; }
        public string? CategoryProduct { get; set; }
        public string? ManagerName { get; set; }
        public ICollection<ProductDetailViewModel>? StorageDetails { get; set; }
    }
}
