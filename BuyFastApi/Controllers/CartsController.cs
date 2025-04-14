using AutoMapper;
using BuyFastApi.Models;
using BuyFastApi.Services;
using BuyFastDTO;
using Microsoft.AspNetCore.Mvc;

namespace BuyFastApi.Controllers;

[Route("api/[controller]")]
public class CartsController : BaseController<CartDto,Cart>
{
    public CartsController(ILogger<ControllerBase> logger, IEntityRepository<Cart> repository, IMapper mapper)
        : base(logger, repository, mapper) { }
}