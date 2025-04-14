using BuyFastApi.Models;
using BuyFastApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BuyFastApi.Controllers;

[Route("api/[controller]")]
public class OrderItemsController : BaseController<OrderItem>
{
    public OrderItemsController(ILogger<ControllerBase> logger, IEntityRepository<OrderItem> repository)
        : base(logger, repository) { }
}