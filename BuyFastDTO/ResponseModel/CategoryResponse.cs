namespace BuyFastDTO.ResponseModel
{
    public class CategoryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? ParentCategoryId { get; set; }

        public DateTime createdAt { get; set; }
    }
}
