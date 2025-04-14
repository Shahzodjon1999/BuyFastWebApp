using AutoMapper;
using BuyFastApi.Infrastructure;
using BuyFastApi.Models;
using BuyFastApi.Services;
using BuyFastDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BuyFastApi.Controllers;


[Route("[controller]")]
public class ProductsController : BaseController<ProductDto,Product>
{
    public ProductsController(ILogger<ProductsController> logger, IEntityRepository<Product> repository,IMapper mapper) : base(logger, repository, mapper) { }
}