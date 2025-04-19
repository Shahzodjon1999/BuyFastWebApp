using BuyFastApi.InterfaceServices;
using BuyFastApi.Models;
using BuyFastDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuyFastApi.Controllers;
[Authorize]
[Route("api/[controller]")]
public class OrderItemsController : BaseController<OrderDto,OrderItem>
{
    public OrderItemsController(ILogger<ControllerBase> logger,IGenericService<OrderDto,OrderItem> service)
        : base(logger, service) { }
}