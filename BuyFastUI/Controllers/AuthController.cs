using BuyFastDTO.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace BuyFastUI.Controllers
{
    public class AuthController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AuthController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest model)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.PostAsJsonAsync("https://your-api.com/api/auth/login", model);

            if (response.IsSuccessStatusCode)
            {
                var jwt = await response.Content.ReadAsStringAsync();

                // Save JWT in cookie or session
                HttpContext.Session.SetString("JWT", jwt);

                return RedirectToAction("Index", "Product");
            }

            ModelState.AddModelError("", "Invalid login");
            return View(model);
        }
    }
}
