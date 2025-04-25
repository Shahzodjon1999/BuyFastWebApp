using BuyFastDTO.RequestModels;
using BuyFastDTO.ResponseModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BuyFastUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AccountController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest model)
        {
            var client = _httpClientFactory.CreateClient("ApiClient");
            var response = await client.PostAsJsonAsync("/api/auth/login", model);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadFromJsonAsync<AuthResponse>();

                // Save JWT in cookie or session
                HttpContext.Session.SetString("JWToken", content.Token);

                return RedirectToAction("Index", "Product");
            }

            ModelState.AddModelError("", "Invalid login");
            return View(model);
        }

        // GET: /Account/Login
        public ActionResult Login()
        {
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            return RedirectToAction("Index", "Product");
        }
    }
}
