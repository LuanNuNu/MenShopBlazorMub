using System.ComponentModel.DataAnnotations;

namespace MenShopBlazor.DTOs.Category
{
    public class CreateUpdateCategoryDTO
    {
        public int? CategoryId { get; set; }

        [Required(ErrorMessage = "Tên danh mục không được để trống.")]
        [StringLength(50, ErrorMessage = "Tên danh mục không được vượt quá 50 ký tự.")]
        public string? Name { get; set; }
    }

}
