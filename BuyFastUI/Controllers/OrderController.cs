using BuyFastDTO.RequestModels;
using BuyFastDTO;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using BuyFastUI.Exctentions;

namespace BuyFastUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpClientFactory _httpClientFactory;
        public OrderController(ILogger<ProductController> logger, IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClientFactory.CreateClient("ApiClient");

            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<OrderItemDto>>("Cart") ?? new();
            return View(cart);
        }


        [HttpPost]
        public async Task<IActionResult> SubmitOrder(OrderRequest model)
        {
            var token = HttpContext.Session.GetString("JWToken");
            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Login", "Account");
            }

            var client = _httpClientFactory.CreateClient("ApiClient");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await client.PostAsJsonAsync("api/orders", model);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Success");
            }

            ModelState.AddModelError("", "Failed to submit order.");
            return View("Checkout", model);
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
