using BuyFastDTO;
using BuyFastUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Http.Headers;
using BuyFastDTO.ResponseModel;
using BuyFastUI.Exctentions;
using System.Reflection;

namespace BuyFastUI.Controllers;

public class ProductController : Controller
{
    private readonly ILogger<ProductController> _logger;
    private readonly HttpClient _httpClient;
    private readonly IHttpClientFactory _httpClientFactory;
    public ProductController(ILogger<ProductController> logger, IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
    {
        _logger = logger;
        _httpClient = httpClientFactory.CreateClient("ApiClient");

        _httpClientFactory = httpClientFactory;
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

    //public async Task<IActionResult> AddToCart(Guid id)
    //{
    //    var token = HttpContext.Session.GetString("JWToken");
    //    if (string.IsNullOrEmpty(token))
    //    {
    //        return RedirectToAction("Login", "Account");
    //    }
    //    var client = _httpClientFactory.CreateClient("ApiClient");
    //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

    //    // Получаем корзину пользователя
    //    var response = await client.GetFromJsonAsync<List<OrderItemResponse>>("api/OrderItems");

    //    // Подгружаем продукты по id товаров в корзине
    //    var productIds = response.Select(x => x.ProductId).ToList();
    //    var products = await _httpClient.GetFromJsonAsync<List<ProductResponse>>($"api/Products/Id?id={id}");

    //    // Теперь сопоставляем товары и создаем OrderItem список
    //    var orderItems = response.Select(cartItem =>
    //    {
    //        var product = products.FirstOrDefault(p => p.Id == cartItem.ProductId);

    //        return new OrderItemResponse
    //        {
    //            ProductId = product.Id,
    //            Quantity = cartItem.Quantity,
    //            UnitPrice = product.Price,
    //            ProductImageUrl = product.ImageUrl,
    //            ProductName = product.Name,
    //        };
    //    }).ToList();

    //    return View(orderItems);
    //}
    public async Task<IActionResult> AddToCart(Guid id)
    {
        var cart = HttpContext.Session.GetObjectFromJson<List<OrderItemDto>>("Cart") ?? new List<OrderItemDto>();

        var existingItem = cart.FirstOrDefault(p => p.ProductId == id);
        if (existingItem != null)
        {
            existingItem.Quantity++;
        }
        else
        {
            var product = await _httpClient.GetFromJsonAsync<ProductResponse>($"api/Products/Id?id={id}");
            if (product == null) return NotFound();

            cart.Add(new OrderItemDto
            {
                ProductId = product.Id,
                ProductName = product.Name,
                Quantity = 1,
                UnitPrice = product.Price
            });
        }

        HttpContext.Session.SetObjectAsJson("Cart", cart);

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