using System.ComponentModel.DataAnnotations;

namespace MenShopBlazor.DTOs.Category
{

    public class CreateCategoryDTO
    {
        [Required(ErrorMessage = "Tên danh mục không được để trống")]
        public string Name { get; set; }
    }
}
