using BuyFastApi.Models;
using BuyFastApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BuyFastApi.Controllers;

[Route("api/[controller]")]
public class WishlistItemsController : BaseController<WishlistItem>
{
    public WishlistItemsController(ILogger<ControllerBase> logger, IEntityRepository<WishlistItem> repository)
        : base(logger, repository) { }
}