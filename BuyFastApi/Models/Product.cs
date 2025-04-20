using BuyFastApi.Abstracts;

namespace BuyFastApi.Models;

// Product
public class Product : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public string? ImageUrl { get; set; }
    public bool IsActive { get; set; } = true;
    
    public Guid CategoryId { get; set; }
    public virtual Category Category { get; set; }
    public virtual ICollection<Review> Reviews { get; set; }
    public virtual ICollection<Rating> Ratings { get; set; }
}