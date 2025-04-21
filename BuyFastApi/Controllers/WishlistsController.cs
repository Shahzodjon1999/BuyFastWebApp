using BuyFastApi.InterfaceServices;
using BuyFastApi.Models;
using BuyFastDTO;
using BuyFastDTO.ResponseModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuyFastApi.Controllers;
[Authorize]
[Route("api/[controller]")]
public class WishlistsController : BaseController<WishlistDto, WishlistResponse, Wishlist>
{
    public WishlistsController(ILogger<ControllerBase> logger, IGenericService<WishlistDto, WishlistResponse, Wishlist> service)
        : base(logger, service) { }
}