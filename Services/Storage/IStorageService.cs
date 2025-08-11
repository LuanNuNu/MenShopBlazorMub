using MenShopBlazor.DTOs.Product.ViewModel;
using MenShopBlazor.DTOs.Storage;

namespace MenShopBlazor.Services.Storage
{
    public interface IStorageService
    {
        Task<List<StorageViewModel>?> GetAllProductsStorageAsync();
        Task<IEnumerable<ProductDetailViewModel>> GetByProductDetailId(int productId);
        Task<List<ProductViewModel>> GetByProductId(int storageId);
    }
}
