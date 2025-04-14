using BuyFastApi.Models;
using BuyFastApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BuyFastApi.Controllers;

[Route("api/[controller]")]
public class UsersController : BaseController<User>
{
    public UsersController(ILogger<ControllerBase> logger, IEntityRepository<User> repository)
        : base(logger, repository) { }
}