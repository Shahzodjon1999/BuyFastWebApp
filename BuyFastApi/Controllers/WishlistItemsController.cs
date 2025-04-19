using BuyFastApi.InterfaceServices;
using BuyFastApi.Models;
using BuyFastDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuyFastApi.Controllers;
[Authorize]
[Route("api/[controller]")]
public class WishlistItemsController : BaseController<WishlistDto,WishlistItem>
{
    public WishlistItemsController(ILogger<ControllerBase> logger, IGenericService<WishlistDto,WishlistItem> service)
        : base(logger, service) { }
}