using WebApplication1.Models.DTOs;

namespace WebApplication1.DTOs
{
    public sealed class ProductInfoDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public bool IsFavorite { get; set; }
        public bool IsProductInBasket { get; set; }
        public string[] Images { get; set; }
        public string Composition { get; set; }
        public int Count { get; set; }
        public string WrapperImage { get; set; }
    }
}
