using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models.DTOs;

[Table("images")]
public sealed class ImageDto
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Column("file_name")] 
    public string FileName { get; set; } = string.Empty;

    public ICollection<ProductAndImageDto>? ProductAndImageDtos { get; set; }
}