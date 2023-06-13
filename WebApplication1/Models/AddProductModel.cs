using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Models.DTOs;

namespace WebApplication1.Models;

public sealed class AddProductModel
{
    public IFormFile WrapperImage { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Composition { get; set; } = string.Empty;
    public IFormFileCollection Photos { get; set; }
    public string CategoryId { get; set; }
    public IEnumerable<SelectListItem> Categories { get; set; }
    public int Count { get; set; }
    public double Price { get; set; }
}