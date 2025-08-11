using MenShopBlazor.DTOs.AddressDTO;

namespace MenShopBlazor.DTOs.Account

{
    public class UserViewModel
    {
        public string? UserId { get; set; }
        public string? FullName { get; set; }
        public string? Avatar { get; set; }
        public string? UserEmail { get; set; }
        public string? UserPhone { get; set; }
        public string? UserRole { get; set; }
        public bool? Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public AddressInfo? WorkArea { get; set; }
        public string? ManagerName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? DisabledDate { get; set; }
        public bool IsDisabled { get; set; }
        public int? BranchId { get; set; }
        public string? BranchName { get; set; }
        public List<ClaimViewModel>? Claims { get; set; }
    }
    public class ClaimViewModel
    {
        public string? Type { get; set; }
        public string? Value { get; set; }
    }
}
