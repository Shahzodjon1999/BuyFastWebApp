using BuyFastDTO;
using BuyFastUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Http.Headers;

namespace BuyFastUI.Controllers;

public class ProductController : Controller
{
    private readonly ILogger<ProductController> _logger;
    private readonly HttpClient _httpClient;
    
    public ProductController(ILogger<ProductController> logger, IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
    {
        _logger = logger;
        _httpClient = httpClientFactory.CreateClient("ApiClient");

        // Optionally attach JWT token if stored in session
        var token = httpContextAccessor.HttpContext?.Session.GetString("JWT");
        if (!string.IsNullOrEmpty(token))
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
    }

    public async Task<IActionResult> Index()
    {
        var response = await _httpClient.GetFromJsonAsync<List<ProductResponse>>("api/products");
        return View(response);
    }

    public async Task<IActionResult> Details(Guid id)
    {
       
        var product = await _httpClient.GetFromJsonAsync<ProductResponse>($"api/Products/Id?id={id}");
        if (product == null)
        {
            return NotFound();
        }

        return View(product);
    }

    public async Task<IActionResult> AddToCart(Guid id)
    {
        var product = await _httpClient.GetFromJsonAsync<ProductResponse>($"api/Products/Id?id={id}");
        if (product == null) return NotFound();

        // ������ ������� � ������
        // var cart = _httpClient.Session.Get<List<Guid>>("Cart") ?? new List<Guid>();
        // cart.Add(product.Id);
        // HttpContext.Session.Set("Cart", cart);

        TempData["Success"] = $"{product.Name} added to cart!";
        return RedirectToAction("Index");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}