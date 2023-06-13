using WebApplication1.DTOs;
using WebApplication1.Models.DTOs;

namespace WebApplication1.Models;

public sealed class ProductsListModel
{
    public List<ProductDto>? Products { get; set; }
    public List<ProductsWithFavDto>? ProductsWithFavs { get; set; }
}