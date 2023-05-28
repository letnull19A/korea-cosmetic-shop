using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models.DTOs;

[Table("categories")]
public sealed class CategoryDto
{
    [Key]
    [Column("id")]
    public Guid CategoryId { get; set; } = new Guid();
    
    [Column("name")]
    public string Name { get; set; } = string.Empty;

    public ICollection<ProductDto>? ProductDtos { get; set; }
}