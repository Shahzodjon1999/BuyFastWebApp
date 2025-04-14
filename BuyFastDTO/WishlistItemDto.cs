namespace BuyFastDTO;

public class WishlistItemDto
{
    public Guid Id { get; set; }
    public Guid WishlistId { get; set; }
    public Guid ProductId { get; set; }
}
