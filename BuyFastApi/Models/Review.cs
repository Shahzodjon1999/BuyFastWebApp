using BuyFastApi.Abstracts;

namespace BuyFastApi.Models;

// Review
public class Review : BaseEntity
{
    public Guid ProductId { get; set; }
    public Guid UserId { get; set; }
    public string Comment { get; set; }
    
    public ICollection<Review> Reviews { get; set; }

    public virtual Product Product { get; set; }
    public virtual User User { get; set; }
}