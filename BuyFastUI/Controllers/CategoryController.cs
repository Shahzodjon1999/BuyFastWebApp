using BuyFastDTO.ResponseModel;
using Microsoft.AspNetCore.Mvc;

namespace BuyFastUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly HttpClient _httpClient;

        public CategoryController(ILogger<ProductController> logger, IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("ApiClient");
        }

        public async Task<IActionResult> Categories()
        {
            var categories = await _httpClient.GetFromJsonAsync<List<CategoryResponse>>("api/Categories"); // or wherever you get your data
            return View(categories);
        }

        public async Task<IActionResult> GetCategoryList()
        {
            var categories = await _httpClient.GetFromJsonAsync<List<CategoryResponse>>("api/Categories");
            return PartialView("_CategoryListPartial", categories);
        }
    }
}
