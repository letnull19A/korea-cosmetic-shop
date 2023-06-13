using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models.DTOs;

[Table("favorites")]
public sealed class FavoriteDto
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; } = Guid.NewGuid();
    
    [Column("user_id")]
    public Guid UserId { get; set; }
    
    [Column("product_id")]
    public Guid ProductId { get; set; }

    public UserDto? UserDtos { get; set; }
    public ProductDto? ProductDtos { get; set; }
}