using System.ComponentModel.DataAnnotations;

namespace MenShopBlazor.DTOs.Account

{
    public class AccountRegisterDTO
    {
        [Required(ErrorMessage = "Họ và tên không được để trống.")]
        [StringLength(30, ErrorMessage = "Họ và tên không được vượt quá 30 ký tự.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email không được để trống.")]
        [EmailAddress(ErrorMessage = "Email không đúng định dạng.")]
        [StringLength(100, ErrorMessage = "Email không được vượt quá 100 ký tự.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được để trống.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Mật khẩu phải từ 6 đến 100 ký tự.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn giới tính.")]
        public bool Gender { get; set; }

        [Required(ErrorMessage = "Ngày sinh không được để trống")]
        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }

        [StringLength(200, ErrorMessage = "Địa chỉ không được vượt quá 200 ký tự.")]
        public string? EmployeeAddress { get; set; }

        [Required(ErrorMessage = "Số điện thoại không được để trống.")]
        [RegularExpression(@"^(0\d{9})$", ErrorMessage = "Số điện thoại phải bắt đầu bằng 0 và có 10 chữ số.")]
        public string? PhoneNumber { get; set; }

        public int? BranchId { get; set; }

        [StringLength(50, ErrorMessage = "Vai trò không được vượt quá 50 ký tự.")]
        public string? Role { get; set; }
    }

}
