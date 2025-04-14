using BuyFastApi.Abstracts;

namespace BuyFastApi.Models;

// Wishlist
public class Wishlist : BaseEntity
{
    public Guid UserId { get; set; }
    public virtual User User { get; set; }
    public virtual ICollection<WishlistItem> Items { get; set; }
}