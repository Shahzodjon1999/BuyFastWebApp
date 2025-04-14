using BuyFastApi.Models;
using BuyFastApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BuyFastApi.Controllers;

[Route("api/[controller]")]
public class UserProfilesController : BaseController<UserProfile>
{
    public UserProfilesController(ILogger<ControllerBase> logger, IEntityRepository<UserProfile> repository)
        : base(logger, repository) { }
}