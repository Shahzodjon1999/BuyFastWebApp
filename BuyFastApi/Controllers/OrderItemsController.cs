using AutoMapper;
using BuyFastApi.Models;
using BuyFastApi.Services;
using BuyFastDTO;
using Microsoft.AspNetCore.Mvc;

namespace BuyFastApi.Controllers;

[Route("api/[controller]")]
public class OrderItemsController : BaseController<OrderDto,OrderItem>
{
    public OrderItemsController(ILogger<ControllerBase> logger, IEntityRepository<OrderItem> repository, IMapper mapper)
        : base(logger, repository, mapper) { }
}