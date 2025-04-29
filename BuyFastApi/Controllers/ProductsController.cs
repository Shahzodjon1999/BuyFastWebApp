using BuyFastApi.InterfaceServices;
using BuyFastApi.Models;
using BuyFastDTO;
using BuyFastDTO.RequestModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;

namespace BuyFastApi.Controllers;

[Authorize]
[Route("api/[controller]")]
public class ProductsController : BaseController<ProductRequest,ProductResponse,Product>
{
    private readonly IGenericService<ProductRequest, ProductResponse, Product> _service;

    public ProductsController(ILogger<ProductsController> logger, IGenericService<ProductRequest, ProductResponse, Product> service)
        : base(logger, service)
    {
        _service = service;
    }
    
    [HttpPost]
    public override ActionResult<string> Create([FromForm] ProductRequest userRequest)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Handle the image upload
            var files = Request.Form.Files;
            if (files.Any())
            {
                var file = files.First();
                var uploadsFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");

                // Ensure the uploads folder exists
                if (!Directory.Exists(uploadsFolderPath))
                {
                    Directory.CreateDirectory(uploadsFolderPath);
                }

                // Generate a unique file name
                var uniqueFileName = Guid.NewGuid()+ Path.GetExtension(file.FileName);

                // Full path to save the file
                var filePath = Path.Combine(uploadsFolderPath, uniqueFileName);

                // Save the file to the server
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    // Use await to ensure the async operation completes
                    file.CopyToAsync(fileStream).Wait();
                }

                // Save only the file name to the userRequest object
                userRequest.ImageUrl = uniqueFileName;
            }

            return _service.Create(userRequest);
        }
        catch (MySqlException ex)
        {
            return StatusCode(500, $"Database error: {ex.Message}");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [AllowAnonymous]
    [HttpGet]
    public override ActionResult<IEnumerable<Product>> GetAll()
    {
        Product productResponse = null;
        try
        {
            var product = _service.GetAll();
            var baseUrl = $"{Request.Scheme}://{Request.Host}{Request.PathBase}";

            var productResponses = product.Select(productOption => new Product
            {
                Id = productOption.Id,
                Name = productOption.Name,
                Description = productOption.Description,
                Price = productOption.Price,
                StockQuantity = productOption.StockQuantity,
                ImageUrl = !string.IsNullOrEmpty(productOption.ImageUrl)
                            ? $"{baseUrl}/{productOption.ImageUrl}"
                            : null,
                IsActive = productOption.IsActive,
                CategoryId = productOption.CategoryId,
                Reviews = productOption.Reviews,
                Ratings = productOption.Ratings
            });

            return Ok(productResponses);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Internal server error");
        }
    }
    
    [AllowAnonymous]
    [HttpGet("Id")]
    public override ActionResult<Product> GetById(Guid id)
    {
        var getItem = _service.GetById(id);
        var baseUrl = $"{Request.Scheme}://{Request.Host}{Request.PathBase}";
        
        Product productResponse = new Product
        {
         Id = getItem.Id,
         Name = getItem.Name,
         Description = getItem.Description,
         Price = getItem.Price,
         StockQuantity = getItem.StockQuantity,
         ImageUrl = !string.IsNullOrEmpty(getItem.ImageUrl)
             ? $"{baseUrl}/{getItem.ImageUrl}"
             : null,
         IsActive = getItem.IsActive,
         CategoryId = getItem.CategoryId,
         Reviews = getItem.Reviews,
         Ratings = getItem.Ratings
        };
        return Ok(productResponse);
    }
}