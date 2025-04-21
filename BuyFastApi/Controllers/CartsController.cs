using BuyFastApi.InterfaceServices;
using BuyFastApi.Models;
using BuyFastDTO;
using BuyFastDTO.ResponseModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuyFastApi.Controllers;
[Authorize]
[Route("api/[controller]")]
public class CartsController : BaseController<CartDto, CartResponse, Cart>
{
    public CartsController(ILogger<ControllerBase> logger, IGenericService<CartDto, CartResponse, Cart> service)
        : base(logger, service) { }
}