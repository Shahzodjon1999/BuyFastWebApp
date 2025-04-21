using BuyFastApi.InterfaceServices;
using BuyFastApi.Models;
using BuyFastDTO;
using BuyFastDTO.ResponseModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuyFastApi.Controllers;

[Authorize]
[Route("api/[controller]")]
public class ReviewsController : BaseController<ReviewDto, ReviewResponse, Review>
{
    public ReviewsController(ILogger<ControllerBase> logger, IGenericService<ReviewDto, ReviewResponse, Review> service)
        : base(logger, service) { }
}