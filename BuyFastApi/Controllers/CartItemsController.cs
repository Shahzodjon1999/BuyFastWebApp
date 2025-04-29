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
    private readonly IGenericService<CartItemDto, CardItemResponse, CartItem> _service;
    public CartItemsController(ILogger<ControllerBase> logger, IGenericService<CartItemDto, CardItemResponse,CartItem> service)
        : base(logger, service) {_service = service; }
    
    [AllowAnonymous]
    [HttpGet]
    public override ActionResult<IEnumerable<CartItem>> GetAll()
    {
        OrderItemResponse itemResponse = null;
        try
        {
            var product = _service.GetAll();
            var baseUrl = $"{Request.Scheme}://{Request.Host}{Request.PathBase}";

            var OrderItemResponse = product.Select(productOption => new CartItem
            {
                Id = productOption.Id,
                Product = productOption.Product,
                Quantity = productOption.Quantity,
                CartId = productOption.CartId,
                ProductId = productOption.ProductId,
                Cart = productOption.Cart,
            });

            return Ok(OrderItemResponse);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Internal server error");
        }
    }
}