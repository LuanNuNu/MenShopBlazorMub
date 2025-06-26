using MenShopBlazor.DTOs.Product.ViewModel;

namespace MenShopBlazor.DTOs.Category
{
    public class CategoryGroupViewModel
    {
        public string CategoryName { get; set; } = string.Empty;
        public List<ProductViewModel> Products { get; set; } = new List<ProductViewModel>();
    }
}
