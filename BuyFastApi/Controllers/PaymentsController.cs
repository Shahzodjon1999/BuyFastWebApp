using BuyFastApi.Models;
using BuyFastApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BuyFastApi.Controllers;

[Route("api/[controller]")]
public class PaymentsController : BaseController<Payment>
{
    public PaymentsController(ILogger<ControllerBase> logger, IEntityRepository<Payment> repository)
        : base(logger, repository) { }
}