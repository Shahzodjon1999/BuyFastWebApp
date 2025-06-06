namespace BuyFastDTO;

public class ProductResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    
    public int StockQuantity { get; set; }
    public decimal Price { get; set; }
    public Guid CategoryId { get; set; }
}



