using System.ComponentModel.DataAnnotations;

namespace MenShopBlazor.DTOs.Size
{
    public class SizeDTO
    {
        public int SizeId { get; set; }
        [Required(ErrorMessage = "Tên kích cở không được để trống")]

        public string? Name { get; set; }
    }
}
