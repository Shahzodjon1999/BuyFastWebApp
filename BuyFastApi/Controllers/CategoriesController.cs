using BuyFastApi.Models;
using BuyFastApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BuyFastApi.Controllers;

[Route("api/[controller]")]
public class CategoriesController : BaseController<Category>
{
    public CategoriesController(ILogger<ControllerBase> logger, IEntityRepository<Category> repository)
        : base(logger, repository) { }
}