using BuyFastApi.InterfaceServices;
using BuyFastApi.Models;
using BuyFastDTO;
using BuyFastDTO.ResponseModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuyFastApi.Controllers;
[Authorize]
[Route("api/[controller]")]
public class UserProfilesController : BaseController<UserProfileDto, UserProfileResponse, UserProfile>
{
    public UserProfilesController(ILogger<ControllerBase> logger, IGenericService<UserProfileDto, UserProfileResponse, UserProfile> service)
        : base(logger, service) { }
}