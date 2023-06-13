using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models.DTOs;

[Table("reviews")]
public sealed class ReviewDto
{
    [Key] [Column("id")] 
    public Guid Id { get; set; } = Guid.NewGuid();

    [Column("user_id")]
    public Guid UserId { get; set; }
    
    [Column("product_id")]
    public Guid ProductId { get; set; }

    [Column("message")] 
    public string Message { get; set; } = string.Empty;

    [Column("rating")] 
    public int Rating { get; set; } = 5;
    
    [Column("date")]
    public DateTime Date { get; set; } = DateTime.UtcNow;
}