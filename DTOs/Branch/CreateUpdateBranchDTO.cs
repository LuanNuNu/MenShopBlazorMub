using System.ComponentModel.DataAnnotations;

namespace MenShopBlazor.DTOs.Branch
{
    public class CreateUpdateBranchDTO
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "Tên chi nhánh không được để trống.")]
        [StringLength(50, ErrorMessage = "Tên không được vượt quá 50 ký tự.")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Địa chỉ không được để trống.")]
        [StringLength(50, ErrorMessage = "Địa chỉ không được vượt quá 50 ký tự.")]
        public string? Address { get; set; }
        public bool IsOnline { get; set; }
    }
}
