namespace BuyFastDTO;

public class WishlistDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public List<WishlistItemDto> Items { get; set; } = new();
}
