using BuyFastApi.InterfaceServices;
using BuyFastApi.Models;
using BuyFastDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuyFastApi.Controllers;
[Authorize]
[Route("api/[controller]")]
public class PaymentsController : BaseController<PaymentDto,Payment>
{
    public PaymentsController(ILogger<ControllerBase> logger, IGenericService<PaymentDto,Payment> service)
        : base(logger, service) { }
}