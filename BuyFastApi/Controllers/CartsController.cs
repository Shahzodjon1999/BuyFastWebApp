using BuyFastApi.Models;
using BuyFastApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BuyFastApi.Controllers;

[Route("api/[controller]")]
public class CartsController : BaseController<Cart>
{
    public CartsController(ILogger<ControllerBase> logger, IEntityRepository<Cart> repository)
        : base(logger, repository) { }
}