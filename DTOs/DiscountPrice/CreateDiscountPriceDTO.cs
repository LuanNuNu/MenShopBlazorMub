using System.ComponentModel.DataAnnotations;

namespace MenShopBlazor.DTOs.DiscountPrice
{
    public class CreateDiscountPriceDTO
    {
        [Required(ErrorMessage = "Tên chương trình không được để trống")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập % giảm giá")]
        public decimal DiscountPercent { get; set; }
        [Required(ErrorMessage = "Mô tả không được để trống")]

        public string? Description { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public bool IsActive { get; set; }
    }
}
