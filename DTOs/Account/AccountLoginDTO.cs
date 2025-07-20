using System.ComponentModel.DataAnnotations;

namespace MenShopBlazor.DTOs.Account
{
    public class AccountLoginDTO
    {
        [Required(ErrorMessage = "Vui lòng nhập email hoặc số điện thoại.")]
        public string Identifier { get; set; } = null!;

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu.")]
        public string Password { get; set; } = null!;
    }

}
