using AutoMapper;
using BuyFastApi.Models;
using BuyFastApi.Services;
using BuyFastDTO;
using Microsoft.AspNetCore.Mvc;

namespace BuyFastApi.Controllers;

[Route("api/[controller]")]
public class UserProfilesController : BaseController<UserProfileDto,UserProfile>
{
    public UserProfilesController(ILogger<ControllerBase> logger, IEntityRepository<UserProfile> repository, IMapper mapper)
        : base(logger, repository, mapper) { }
}