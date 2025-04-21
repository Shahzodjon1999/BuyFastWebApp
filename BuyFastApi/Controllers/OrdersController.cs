using BuyFastApi.InterfaceServices;
using BuyFastApi.Models;
using BuyFastDTO;
using BuyFastDTO.ResponseModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuyFastApi.Controllers;
[Authorize]
[Route("api/[controller]")]
public class OrdersController : BaseController<OrderDto, OrderResponse, Order>
{
    public OrdersController(ILogger<ControllerBase> logger, IGenericService<OrderDto, OrderResponse, Order> service)
        : base(logger, service) { }
}