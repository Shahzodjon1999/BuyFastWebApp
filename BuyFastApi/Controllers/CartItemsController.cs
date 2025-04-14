using AutoMapper;
using BuyFastApi.Models;
using BuyFastApi.Services;
using BuyFastDTO;
using Microsoft.AspNetCore.Mvc;

namespace BuyFastApi.Controllers;

[Route("api/[controller]")]
public class CartItemsController : BaseController<CartItemDto,CartItem>
{
    public CartItemsController(ILogger<ControllerBase> logger, IEntityRepository<CartItem> repository, IMapper mapper)
        : base(logger, repository, mapper) { }
}