using BuyFastApi.Models;
using BuyFastApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BuyFastApi.Controllers;

[Route("api/[controller]")]
public class OrdersController : BaseController<Order>
{
    public OrdersController(ILogger<ControllerBase> logger, IEntityRepository<Order> repository)
        : base(logger, repository) { }
}