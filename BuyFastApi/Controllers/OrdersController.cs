using AutoMapper;
using BuyFastApi.Models;
using BuyFastApi.Services;
using BuyFastDTO;
using Microsoft.AspNetCore.Mvc;

namespace BuyFastApi.Controllers;

[Route("api/[controller]")]
public class OrdersController : BaseController<OrderDto,Order>
{
    public OrdersController(ILogger<ControllerBase> logger, IEntityRepository<Order> repository, IMapper mapper)
        : base(logger, repository, mapper) { }
}