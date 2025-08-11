using Blazored.SessionStorage;
using MenShopBlazor;
using MenShopBlazor.Services;
using MenShopBlazor.Services.Account;
using MenShopBlazor.Services.Address;
using MenShopBlazor.Services.Admin;
using MenShopBlazor.Services.Auth;
using MenShopBlazor.Services.Branch;
using MenShopBlazor.Services.Cart;
using MenShopBlazor.Services.Category;
using MenShopBlazor.Services.Collection;
using MenShopBlazor.Services.CollectionService;
using MenShopBlazor.Services.Color;
using MenShopBlazor.Services.CustomerAddress;
using MenShopBlazor.Services.DiscountPrice;
using MenShopBlazor.Services.Fabric;
using MenShopBlazor.Services.InputReceiptService;
using MenShopBlazor.Services.Order;
using MenShopBlazor.Services.OutputReceiptService;
using MenShopBlazor.Services.Payment;
using MenShopBlazor.Services.Product;
using MenShopBlazor.Services.Size;
using MenShopBlazor.Services.Statistic;
using MenShopBlazor.Services.Storage;
using MenShopBlazor.Services.Token;
using MenShopBlazor.Services.UploadImage;
using MenShopBlazor.Shared;
using MenShopUI.Services.Color;
using MenShopUI.Services.Fabric;
using MenShopUI.Services.Size;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using MudBlazor.Services;
using System.Globalization;

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
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<ICustomerAddressService, CustomerAddressService>();
builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped<IOutputReceiptService, OutputReceiptService>();
builder.Services.AddScoped<IInputReceiptService, InputReceiptService>();
builder.Services.AddScoped<ICollectionService, CollectionService>();
builder.Services.AddScoped<IDiscountPriceService, DiscountPriceService>();
builder.Services.AddScoped<IStorageService, StorageService>();
builder.Services.AddScoped<IStatisticService, StatisticService>();
builder.Services.AddScoped<BranchHelper>();
builder.Services.AddSingleton<CartState>();
builder.Services.AddScoped<IForgotPasswordService, ForgotPasswordService>();


builder.Services.AddHttpClient("AuthorizedClient", client =>
{
    client.BaseAddress = new Uri("https://localhost:7094/");
})
.AddHttpMessageHandler<AuthorizationMessageHandler>();

builder.Services.AddScoped<HttpClient>(sp => new HttpClient { BaseAddress = new Uri("http://localhost:7094/") });
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
