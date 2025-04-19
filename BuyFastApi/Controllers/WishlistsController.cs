using BuyFastApi.InterfaceServices;
using BuyFastApi.Models;
using BuyFastDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuyFastApi.Controllers;
[Authorize]
[Route("api/[controller]")]
public class WishlistsController : BaseController<WishlistDto,Wishlist>
{
    public WishlistsController(ILogger<ControllerBase> logger, IGenericService<WishlistDto,Wishlist> service)
        : base(logger, service) { }
}