using System.ComponentModel.DataAnnotations;

namespace MenShopBlazor.DTOs.Account
{
    public class UserBaseUpdateDTO
    {
        [StringLength(30)]
        public string? FullName { get; set; }

        [StringLength(100)]
        public string? PhoneNumber { get; set; }

        public DateTime? BirthDate { get; set; }

        public bool? Gender { get; set; }

        public string? Avatar { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

    }
}
