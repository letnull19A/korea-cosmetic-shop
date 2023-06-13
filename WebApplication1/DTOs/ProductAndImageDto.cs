using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models.DTOs;

[Table("products_and_images")]
public sealed class ProductAndImageDto
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Column("image_id")]
    public Guid ImageId { get; set; }
    
    [Column("product_id")]
    public Guid ProductId { get; set; }

    public ProductDto? ProductDto { get; set; }
    public ImageDto? ImageDto { get; set; }
}