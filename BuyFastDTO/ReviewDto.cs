namespace BuyFastDTO;

public class ReviewDto
{
    public Guid Id { get; set; }
    public string Content { get; set; } = string.Empty;
    public int RatingValue { get; set; }
    public Guid ProductId { get; set; }
    public Guid UserId { get; set; }
}
