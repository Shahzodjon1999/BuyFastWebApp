using BuyFastApi.InterfaceServices;
using BuyFastApi.Models;
using BuyFastDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuyFastApi.Controllers;
[Authorize]
[Route("api/[controller]")]
public class CategoriesController : BaseController<CategoryDto,Category>
{
    public CategoriesController(ILogger<ControllerBase> logger, IGenericService<CategoryDto,Category> service)
        : base(logger, service) { }
}