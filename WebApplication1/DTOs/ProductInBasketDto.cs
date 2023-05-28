namespace WebApplication1.DTOs
{
    public sealed class ProductInBasketDto
    {
        public Guid Id { get; set; }
        public string WrapperImage { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
        public int MaxCount { get; set; }
    }
}
