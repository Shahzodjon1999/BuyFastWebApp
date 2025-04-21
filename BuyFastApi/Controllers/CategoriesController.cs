using BuyFastApi.InterfaceServices;
using BuyFastApi.Models;
using BuyFastDTO.RequestModels;
using BuyFastDTO.ResponseModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuyFastApi.Controllers;
[Authorize]
[Route("api/[controller]")]
public class CategoriesController : BaseController<CategoryRequest,CategoryResponse,Category>
{
    public CategoriesController(ILogger<ControllerBase> logger, IGenericService<CategoryRequest, CategoryResponse,Category> service)
        : base(logger, service) { }
}