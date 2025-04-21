using BuyFastApi.InterfaceServices;
using BuyFastApi.Models;
using BuyFastDTO;
using BuyFastDTO.ResponseModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuyFastApi.Controllers;
[Authorize]
[Route("api/[controller]")]
public class CartItemsController : BaseController<CartItemDto, CardItemResponse,CartItem>
{
    public CartItemsController(ILogger<ControllerBase> logger, IGenericService<CartItemDto, CardItemResponse,CartItem> repository)
        : base(logger, repository) { }
}