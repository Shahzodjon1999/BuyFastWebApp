using BuyFastApi.Abstracts;

namespace BuyFastApi.Models;

// Rating
public class Rating : BaseEntity
{
    public Guid ProductId { get; set; }
    public Guid UserId { get; set; }
    public int Score { get; set; } // from 1 to 5

    public virtual Product Product { get; set; }
    public virtual User User { get; set; }
}