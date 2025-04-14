using BuyFastApi.Models;
using BuyFastApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BuyFastApi.Controllers;

[Route("api/[controller]")]
public class CartItemsController : BaseController<CartItem>
{
    public CartItemsController(ILogger<ControllerBase> logger, IEntityRepository<CartItem> repository)
        : base(logger, repository) { }
}