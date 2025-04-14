using AutoMapper;
using BuyFastApi.Models;
using BuyFastApi.Services;
using BuyFastDTO;
using Microsoft.AspNetCore.Mvc;

namespace BuyFastApi.Controllers;

[Route("api/[controller]")]
public class ReviewsController : BaseController<ReviewDto,Review>
{
    public ReviewsController(ILogger<ControllerBase> logger, IEntityRepository<Review> repository,IMapper mapper)
        : base(logger, repository, mapper) { }
}