using BuyFastApi.Abstracts;

namespace BuyFastApi.Models;

// Payment
public class Payment : BaseEntity
{
    public Guid OrderId { get; set; }
    public string PaymentMethod { get; set; }
    public string Status { get; set; }

    public virtual Order Order { get; set; }
}