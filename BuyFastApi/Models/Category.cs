using BuyFastApi.Abstracts;

namespace BuyFastApi.Models;

// Category
public class Category : BaseEntity
{
    public string Name { get; set; }
    public Guid? ParentCategoryId { get; set; }
    public virtual Category ParentCategory { get; set; }
    public virtual ICollection<Product> Products { get; set; }
}
