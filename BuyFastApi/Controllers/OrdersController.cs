using BuyFastApi.InterfaceServices;
using BuyFastApi.Models;
using BuyFastDTO;
using BuyFastDTO.RequestModels;
using BuyFastDTO.ResponseModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BuyFastApi.Controllers;
[Authorize]
[Route("api/[controller]")]
public class OrdersController : BaseController<OrderRequest, OrderResponse, Order>
{
    private readonly IGenericService<OrderRequest, OrderResponse, Order> _service;
    public OrdersController(ILogger<ControllerBase> logger, IGenericService<OrderRequest, OrderResponse, Order> service)
        : base(logger, service) 
    { 
     service=_service;
    }
}