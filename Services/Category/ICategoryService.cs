
using MenShopBlazor.DTOs;
using MenShopBlazor.DTOs.Category;
using MenShopBlazor.DTOs.Product;

namespace MenShopBlazor.Services.Category
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryModelView>> GetAllCategoriesAsync();
        Task<CategoryModelView?> GetCategoryByIdAsync(int id);
        Task<CategoryModelView?> CreateCategoryAsync(CreateCategoryDTO category);
        Task<CategoryModelView?> UpdateCategoryAsync(CategoryModelView category);
        Task<ApiMessageReponse> DeleteCategoryAsync(int id);
    }
}
