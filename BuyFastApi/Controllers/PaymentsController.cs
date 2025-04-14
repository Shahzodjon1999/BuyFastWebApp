using AutoMapper;
using BuyFastApi.Models;
using BuyFastApi.Services;
using BuyFastDTO;
using Microsoft.AspNetCore.Mvc;

namespace BuyFastApi.Controllers;

[Route("api/[controller]")]
public class PaymentsController : BaseController<PaymentDto,Payment>
{
    public PaymentsController(ILogger<ControllerBase> logger, IEntityRepository<Payment> repository, IMapper mapper)
        : base(logger, repository, mapper) { }
}