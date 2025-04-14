using AutoMapper;
using BuyFastApi.Models;
using BuyFastApi.Services;
using BuyFastDTO.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace BuyFastApi.Controllers;

[Route("api/[controller]")]
public class UsersController : BaseController<UserDto,User>
{
    public UsersController(ILogger<ControllerBase> logger, IEntityRepository<User> repository, IMapper mapper)
        : base(logger, repository, mapper) { }
}