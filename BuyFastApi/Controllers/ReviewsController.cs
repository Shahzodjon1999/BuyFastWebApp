using BuyFastApi.InterfaceServices;
using BuyFastApi.Models;
using BuyFastDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuyFastApi.Controllers;

[Authorize]
[Route("api/[controller]")]
public class ReviewsController : BaseController<ReviewDto,Review>
{
    public ReviewsController(ILogger<ControllerBase> logger, IGenericService<ReviewDto,Review> service)
        : base(logger, service) { }
}