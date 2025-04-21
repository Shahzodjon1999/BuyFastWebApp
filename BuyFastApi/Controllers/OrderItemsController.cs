using BuyFastApi.InterfaceServices;
using BuyFastApi.Models;
using BuyFastDTO;
using BuyFastDTO.ResponseModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuyFastApi.Controllers;
[Authorize]
[Route("api/[controller]")]
public class OrderItemsController : BaseController<OrderDto, OrderItemResponse, OrderItem>
{
    public OrderItemsController(ILogger<ControllerBase> logger,IGenericService<OrderDto, OrderItemResponse, OrderItem> service)
        : base(logger, service) { }
}