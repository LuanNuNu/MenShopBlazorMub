namespace MenShopBlazor.Services.Auth
{
    public interface IAuthService
    {
        Task SetAuthenticatedUserAsync(string token);
        Task LogoutAsync();
    }
}
