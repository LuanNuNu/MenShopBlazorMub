using MenShopBlazor.DTOs.AddressDTO;
using System.ComponentModel.DataAnnotations;

namespace MenShopBlazor.DTOs.Account
{
    public class EmployeeUpdateDTO : UserBaseUpdateDTO
    {
        public int BranchId { get; set; }

        [StringLength(200)]
        public AddressInfo? WorkArea { get; set; }
        public string? NewPassword { get; set; }
    }
}
