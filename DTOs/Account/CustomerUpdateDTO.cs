namespace MenShopBlazor.DTOs.Account
{
    public class CustomerUpdateDTO : UserBaseUpdateDTO
    {
        public string? CurrentPassword { get; set; }
        public string? NewPassword { get; set; }
    }
}
