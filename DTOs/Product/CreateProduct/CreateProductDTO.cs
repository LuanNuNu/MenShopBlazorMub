
using System.ComponentModel.DataAnnotations;

namespace MenShopBlazor.DTOs.Product
{
    public class CreateProductDTO
    {
        [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Mô tả sản phẩm không được để trống")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn danh mục")]
        public int CategoryId { get; set; }
        public bool Status { get; set; }
    }
}
