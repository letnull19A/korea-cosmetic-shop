namespace WebApplication1.DTOs
{
    public sealed class UpdateProductDto
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Composition { get; set; } = string.Empty;
        public int Count { get; set; }
        public double Price { get; set; }
    }
}
