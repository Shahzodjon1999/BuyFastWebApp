using BuyFastApi.InterfaceServices;
using BuyFastApi.Models;
using BuyFastDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuyFastApi.Controllers;
[Authorize]
[Route("api/[controller]")]
public class CartItemsController : BaseController<CartItemDto,CartItem>
{
    public CartItemsController(ILogger<ControllerBase> logger, IGenericService<CartItemDto,CartItem> repository)
        : base(logger, repository) { }
}