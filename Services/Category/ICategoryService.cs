
using MenShopBlazor.DTOs;
using MenShopBlazor.DTOs.Category;
using MenShopBlazor.DTOs.Product;

namespace MenShopBlazor.Services.Category
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryProductViewModel>> GetAllCategoriesAsync();
        Task<CategoryProductViewModel?> GetCategoryByIdAsync(int id);
        Task<ApiResponseModel<object>> CreateCategoryAsync(CreateUpdateCategoryDTO category);
        Task<ApiResponseModel<object>> UpdateCategoryAsync(int categoryId,CreateUpdateCategoryDTO category);
        Task<ApiResponseModel<object>> DeleteCategoryAsync(int categoryId);
    }
}
