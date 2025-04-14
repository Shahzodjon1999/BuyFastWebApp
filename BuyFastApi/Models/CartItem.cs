using BuyFastApi.Abstracts;

namespace BuyFastApi.Models;

// CartItem
public class CartItem : BaseEntity
{
    public Guid CartId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }

    public virtual Cart Cart { get; set; }
    public virtual Product Product { get; set; }
}