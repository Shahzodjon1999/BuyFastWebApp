using BuyFastApi.Abstracts;

namespace BuyFastApi.Models;

// Order
public class Order : BaseEntity
{
    public Guid UserId { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
    public string Status { get; set; } // Pending, Paid, Shipped, Delivered, Cancelled
    public string ShippingAddress { get; set; }
    public virtual User User { get; set; }
    public virtual ICollection<OrderItem> OrderItems { get; set; }
    public virtual Payment Payment { get; set; }
}