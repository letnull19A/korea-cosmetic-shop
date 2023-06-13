using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models.DTOs;

[Table("products")]
public sealed class ProductDto
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; } = Guid.NewGuid();
    
    [Column("category_id")]
    public Guid CategoryId { get; set; }
    
    [Column("name")]
    public string Name { get; set; } = string.Empty;
    
    [Column("description")]
    public string Description { get; set; } = string.Empty;

    [Column("wrapper_image")]
    public string WrapperImage { get; set; } = string.Empty;
    
    [Column("composition")]
    public string Composition { get; set; } = string.Empty;

    [Column("price")] 
    public double Price { get; set; } = 0;

    [Column("count")] 
    public int Count { get; set; } = 0;

    public CategoryDto? Category { get; set; }
    public ICollection<FavoriteDto>? FavoriteDtos { get; set; }
    public ICollection<ProductAndImageDto>? ProductAndImageDtos { get; set; }
}