using BuyFastApi.Models;
using BuyFastApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BuyFastApi.Controllers;

[Route("api/[controller]")]
public class WishlistsController : BaseController<Wishlist>
{
    public WishlistsController(ILogger<ControllerBase> logger, IEntityRepository<Wishlist> repository)
        : base(logger, repository) { }
}