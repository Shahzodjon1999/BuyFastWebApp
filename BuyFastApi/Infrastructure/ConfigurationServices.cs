using BuyFastApi.Authentications;
using BuyFastApi.InterfaceRepositoryes;
using BuyFastApi.InterfaceServices;
using BuyFastApi.Mapping;
using BuyFastApi.Models;
using BuyFastApi.Repositories;
using BuyFastApi.Services;
using BuyFastDTO;
using BuyFastDTO.RequestModels;
using BuyFastDTO.ResponseModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace BuyFastApi.Infrastructure;

public static class ConfigurationServices
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        //addedSwagerConfigure
        services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
        
        //Added AutoMapping
        services.AddAutoMapper(typeof(MappingProfile));
        
        //Added Respositories
        services.AddTransient<ICategoryRepository,CategoryRepository>();
        services.AddTransient<IProductRepository,ProductRepository>();
        services.AddTransient<ICartItemRepository, CartItemRepository>();
        services.AddTransient<IOrderRepository, OrderRepository>();
        
        services.AddTransient<IGenericService<CategoryRequest,CategoryResponse,Category>,CategoryService>();
        services.AddTransient<IGenericService<ProductRequest,ProductResponse,Product>,ProductService>();
        services.AddTransient<IGenericService<CartDto, CardItemResponse, CartItem>, CartItemService>();
        services.AddTransient<IGenericService<OrderRequest, OrderResponse, Order>, OrderService>();
        
        //adding custom Auth
        services.AddAuthToken();
        
        services.AddDbContext<AppDbContext>(options =>
            options.UseMySql(configuration.GetConnectionString("DefaultConnection"),
                ServerVersion.AutoDetect(configuration.GetConnectionString("DefaultConnection"))));
        return services;
    }
}