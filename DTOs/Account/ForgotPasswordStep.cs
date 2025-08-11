using System.ComponentModel.DataAnnotations;

namespace MenShopBlazor.DTOs.Account
{
    public class ForgotPasswordStep
    {
        [Required(ErrorMessage = "Vui lòng nhập Email của bạn!.")]
        public string Email { get; set; }
        public string Otp { get; set; }
        public string NewPassword { get; set; }
        public string SessionId { get; set; }
    }
}
