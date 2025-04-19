using BuyFastApi.InterfaceServices;
using BuyFastApi.Models;
using BuyFastDTO.RequestModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuyFastApi.Controllers;
[Authorize]
[Route("api/[controller]")]
public class UsersController : BaseController<UserDto,User>
{
    public UsersController(ILogger<ControllerBase> logger, IGenericService<UserDto,User> service)
        : base(logger, service) { }
}