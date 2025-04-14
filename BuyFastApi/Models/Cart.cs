using BuyFastApi.Abstracts;

namespace BuyFastApi.Models;

// Cart
public class Cart : BaseEntity
{
    public Guid UserId { get; set; }
    public virtual User User { get; set; }
    public virtual ICollection<CartItem> Items { get; set; }
}