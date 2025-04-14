using AutoMapper;
using BuyFastApi.Models;
using BuyFastApi.Services;
using BuyFastDTO;
using Microsoft.AspNetCore.Mvc;

namespace BuyFastApi.Controllers;

[Route("api/[controller]")]
public class WishlistItemsController : BaseController<WishlistDto,WishlistItem>
{
    public WishlistItemsController(ILogger<ControllerBase> logger, IEntityRepository<WishlistItem> repository, IMapper mapper)
        : base(logger, repository, mapper) { }
}