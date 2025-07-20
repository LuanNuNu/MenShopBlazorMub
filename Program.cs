using MenShopBlazor.Services;
using MenShopBlazor;
using MenShopBlazor.Services.Category;
using MenShopBlazor .Services.Product;
using MenShopBlazor.Services.UploadImage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using MenShopBlazor.Services.Order;
using MenShopBlazor.Services.Payment;
using MenShopBlazor.Services.Fabric;
using MenShopUI.Services.Fabric;
using MenShopBlazor.Services.Color;
using MenShopUI.Services.Color;
using MenShopBlazor.Services.Size;
using MenShopUI.Services.Size;
using MenShopBlazor.Services.Account;
using MenShopBlazor.Services.Auth;
using Blazored.SessionStorage;
using Microsoft.Extensions.DependencyInjection;
using MenShopBlazor.Services.Token;
using MenShopBlazor.Services.Admin;
using Microsoft.AspNetCore.Components.Authorization;
using MenShopBlazor.Services.Branch;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddMudServices();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IFabricService, FabricService>();
builder.Services.AddScoped<IColorService, ColorService>();
builder.Services.AddScoped<ISizeService, SizeService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IUpImg, UpImg>();
builder.Services.AddBlazoredSessionStorage();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<CustomAuthProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(sp => sp.GetRequiredService<CustomAuthProvider>());
builder.Services.AddScoped<AuthorizationMessageHandler>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IBranchService, BranchService>();

builder.Services.AddHttpClient("AuthorizedClient", client =>
{
    client.BaseAddress = new Uri("https://localhost:7094/api/");
})
.AddHttpMessageHandler<AuthorizationMessageHandler>();

builder.Services.AddScoped<HttpClient>(sp => new HttpClient { BaseAddress = new Uri("http://localhost:7094/") });
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
