using BuyFastApi.InterfaceServices;
using BuyFastApi.Models;
using BuyFastDTO.RequestModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuyFastApi.Controllers;

[Authorize]
[Route("api/[controller]")]
public class ProductsController : BaseController<CreateProductDto,Product>
{
    public ProductsController(ILogger<ProductsController> logger, IGenericService<CreateProductDto,Product> service) 
        : base(logger, service) { }
}