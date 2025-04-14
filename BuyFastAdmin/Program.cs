using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BuyFastAdmin;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5222/") });

builder.Services.AddAuthorizationCore(options =>
{
    options.AddPolicy("Admin", policy => policy.RequireClaim("Admin")); 
});
await builder.Build().RunAsync();