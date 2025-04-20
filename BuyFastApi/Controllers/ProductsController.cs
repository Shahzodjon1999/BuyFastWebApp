using BuyFastApi.InterfaceServices;
using BuyFastApi.Models;
using BuyFastDTO.RequestModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuyFastApi.Controllers;

[Authorize]
[Route("api/[controller]")]
public class ProductsController : BaseController<CreateProductDto,Product>
{
    private readonly IGenericService<CreateProductDto, Product> _service;

    public ProductsController(ILogger<ProductsController> logger, IGenericService<CreateProductDto, Product> service)
        : base(logger, service)
    {
        _service = service;
    }
    
    [HttpPost]
    public override ActionResult<string> Create([FromForm] CreateProductDto userRequest)
    {
        try
        {
            // if (!ModelState.IsValid)
            // {
            //     return BadRequest(ModelState);
            // }

            // Handle the image upload
            var files = Request.Form.Files;
            if (files.Any())
            {
                var file = files.First();
                var uploadsFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");

                // Ensure the uploads folder exists
                if (!Directory.Exists(uploadsFolderPath))
                {
                    Directory.CreateDirectory(uploadsFolderPath);
                }

                // Generate a unique file name
                var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

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
        // catch (SqlException ex)
        // {
        //     return StatusCode(500, $"Database error: {ex.Message}");
        // }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}