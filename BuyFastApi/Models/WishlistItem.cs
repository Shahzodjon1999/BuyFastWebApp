using BuyFastApi.Abstracts;

namespace BuyFastApi.Models;

// WishlistItem
public class WishlistItem : BaseEntity
{
    public Guid WishlistId { get; set; }
    public Guid ProductId { get; set; }

    public virtual Wishlist Wishlist { get; set; }
    public virtual Product Product { get; set; }
}
