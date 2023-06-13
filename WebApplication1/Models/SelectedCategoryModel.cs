using WebApplication1.DTOs;
using WebApplication1.Models.DTOs;

namespace WebApplication1.Models
{
    public sealed class SelectedCategoryModel
    {
        public Guid CategoryId { get; set; }
        public string Category { get; set; }
        public List<ProductDto> Products { get; set; }
        public List<ProductsWithFavDto>? ProductsWithFavs { get; set; }
    }
}
