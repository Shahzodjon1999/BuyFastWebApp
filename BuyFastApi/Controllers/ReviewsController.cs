using BuyFastApi.Models;
using BuyFastApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BuyFastApi.Controllers;

[Route("api/[controller]")]
public class ReviewsController : BaseController<Review>
{
    public ReviewsController(ILogger<ControllerBase> logger, IEntityRepository<Review> repository)
        : base(logger, repository) { }
}