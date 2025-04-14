using AutoMapper;
using BuyFastApi.Models;
using BuyFastApi.Services;
using BuyFastDTO;
using Microsoft.AspNetCore.Mvc;

namespace BuyFastApi.Controllers;

[Route("api/[controller]")]
public class CategoriesController : BaseController<CategoryDto,Category>
{
    public CategoriesController(ILogger<ControllerBase> logger, IEntityRepository<Category> repository, IMapper mapper)
        : base(logger, repository, mapper) { }
}