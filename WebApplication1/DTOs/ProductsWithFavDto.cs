namespace WebApplication1.DTOs
{
    public sealed class ProductsWithFavDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsFavorite { get; set; }
        public string WrapperImage { get; set; }
    }
}
