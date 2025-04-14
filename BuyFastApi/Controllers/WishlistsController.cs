using AutoMapper;
using BuyFastApi.Models;
using BuyFastApi.Services;
using BuyFastDTO;
using Microsoft.AspNetCore.Mvc;

namespace BuyFastApi.Controllers;

[Route("api/[controller]")]
public class WishlistsController : BaseController<WishlistDto,Wishlist>
{
    public WishlistsController(ILogger<ControllerBase> logger, IEntityRepository<Wishlist> repository, IMapper mapper)
        : base(logger, repository, mapper) { }
}