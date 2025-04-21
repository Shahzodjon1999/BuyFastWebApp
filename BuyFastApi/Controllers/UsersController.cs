using BuyFastApi.InterfaceServices;
using BuyFastApi.Models;
using BuyFastDTO.RequestModels;
using BuyFastDTO.ResponseModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuyFastApi.Controllers;
[Authorize]
[Route("api/[controller]")]
public class UsersController : BaseController<UserDto, UserResponse, User>
{
    public UsersController(ILogger<ControllerBase> logger, IGenericService<UserDto, UserResponse, User> service)
        : base(logger, service) { }
}