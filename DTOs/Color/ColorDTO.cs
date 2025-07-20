using System.ComponentModel.DataAnnotations;

namespace MenShopBlazor.DTOs.Color
{
    public class ColorDTO
    {
        public int ColorId { get; set; }
        [Required(ErrorMessage = "Tên màu không được để trống")]
        public string? Name { get; set; }
    }
}
