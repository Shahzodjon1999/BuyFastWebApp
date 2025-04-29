namespace BuyFastDTO.ResponseModel
{
    public class OrderResponse
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } 
        public string ShippingAddress { get; set; }
    }
}
