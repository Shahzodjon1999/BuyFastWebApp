namespace BuyFastDTO.ResponseModel
{
    public class OrderItemResponse
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; } // 👈 удобно на фронте
        public string ProductImageUrl { get; set; } // 👈 удобно на фронте
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; } // 👈 чуть яснее
    }
}
