using BuyFastApi.Infrastructure;
using BuyFastApi.Models;
using BuyFastApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BuyFastApi.Controllers;


[Route("[controller]")]
public class ProductsController : BaseController<Product>
{
    public ProductsController(ILogger<ProductsController> logger, IEntityRepository<Product> repository) : base(logger, repository) { }
}