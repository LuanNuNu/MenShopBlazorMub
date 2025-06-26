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

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddMudServices();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IUpImg, UpImg>();
builder.Services.AddScoped<HttpClient>(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5014/") });
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
