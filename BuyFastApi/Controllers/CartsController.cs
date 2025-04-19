using AutoMapper;
using BuyFastApi.InterfaceServices;
using BuyFastApi.Models;
using BuyFastApi.Services;
using BuyFastDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuyFastApi.Controllers;
[Authorize]
[Route("api/[controller]")]
public class CartsController : BaseController<CartDto,Cart>
{
    public CartsController(ILogger<ControllerBase> logger, IGenericService<CartDto,Cart> service)
        : base(logger, service) { }
}