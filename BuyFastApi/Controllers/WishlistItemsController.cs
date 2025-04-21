using BuyFastApi.InterfaceServices;
using BuyFastApi.Models;
using BuyFastDTO;
using BuyFastDTO.ResponseModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuyFastApi.Controllers;
[Authorize]
[Route("api/[controller]")]
public class WishlistItemsController : BaseController<WishlistDto, WishlistItemsResponse, WishlistItem>
{
    public WishlistItemsController(ILogger<ControllerBase> logger, IGenericService<WishlistDto, WishlistItemsResponse, WishlistItem> service)
        : base(logger, service) { }
}