using BuyFastApi.InterfaceServices;
using BuyFastApi.Models;
using BuyFastDTO;
using BuyFastDTO.ResponseModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuyFastApi.Controllers;
[Authorize]
[Route("api/[controller]")]
public class PaymentsController : BaseController<PaymentDto, PaymentResponse, Payment>
{
    public PaymentsController(ILogger<ControllerBase> logger, IGenericService<PaymentDto, PaymentResponse, Payment> service)
        : base(logger, service) { }
}