using BuyFastApi.Authentications;
using BuyFastApi.InterfaceRepositoryes;
using BuyFastApi.InterfaceServices;
using BuyFastApi.Mapping;
using BuyFastApi.Models;
using BuyFastApi.Repositories;
using BuyFastApi.Services;
using BuyFastDTO;
using BuyFastDTO.RequestModels;
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
        
        services.AddTransient<IGenericService<CategoryDto,Category>,CategoryService>();
        services.AddTransient<IGenericService<CreateProductDto,Product>,ProductService>();
        
        //adding custom Auth
        services.AddAuthToken();
        
        services.AddDbContext<AppDbContext>(options =>
            options.UseMySql(configuration.GetConnectionString("DefaultConnection"),
                ServerVersion.AutoDetect(configuration.GetConnectionString("DefaultConnection"))));
        return services;
    }
}