using System.ComponentModel.DataAnnotations;

namespace MenShopBlazor.DTOs.Account
{
    public class EmployeeUpdateDTO : UserBaseUpdateDTO
    {
        public int? BranchId { get; set; }

        [StringLength(200)]
        public string? EmployeeAddress { get; set; }
        public string? NewPassword { get; set; }
    }
}
