using BuyFastApi.Authentications;
using BuyFastApi.Mapping;
using BuyFastApi.Models;
using BuyFastApi.Services;
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
        services.AddTransient<IEntityRepository<Category>,EntityRepository<Category>>();
        services.AddTransient<IEntityRepository<Product>,EntityRepository<Product>>();
        services.AddTransient<IEntityRepository<User>,EntityRepository<User>>();
        services.AddTransient<IEntityRepository<Review>,EntityRepository<Review>>();
        
        //adding custom Auth
        services.AddAuthToken();
        
        services.AddDbContext<AppDbContext>(options =>
            options.UseMySql(configuration.GetConnectionString("DefaultConnection"),
                ServerVersion.AutoDetect(configuration.GetConnectionString("DefaultConnection"))));
        return services;
    }
}