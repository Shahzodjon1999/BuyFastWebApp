using BuyFastApi.InterfaceServices;
using BuyFastApi.Models;
using BuyFastDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuyFastApi.Controllers;
[Authorize]
[Route("api/[controller]")]
public class UserProfilesController : BaseController<UserProfileDto,UserProfile>
{
    public UserProfilesController(ILogger<ControllerBase> logger, IGenericService<UserProfileDto,UserProfile> service)
        : base(logger, service) { }
}