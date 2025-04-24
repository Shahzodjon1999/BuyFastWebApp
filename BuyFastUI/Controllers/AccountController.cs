using BuyFastDTO.RequestModels;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

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

        // GET: /Account/Login
        public ActionResult Login()
        {
            return View();
        }
    }
}
