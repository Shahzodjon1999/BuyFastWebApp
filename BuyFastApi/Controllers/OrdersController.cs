using BuyFastApi.InterfaceServices;
using BuyFastApi.Models;
using BuyFastDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuyFastApi.Controllers;
[Authorize]
[Route("api/[controller]")]
public class OrdersController : BaseController<OrderDto,Order>
{
    public OrdersController(ILogger<ControllerBase> logger, IGenericService<OrderDto,Order> service)
        : base(logger, service) { }
}