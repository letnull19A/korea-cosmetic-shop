using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models.DTOs;

[Table("payment_means")]
public sealed class PaymentMeanDto
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; } = Guid.NewGuid();
    
    [Column("user_id")]
    public Guid UserId { get; set; }

    [Column("system")]
    public string System { get; set; } = string.Empty;

    [Column("card_number")]
    public string CardNumber { get; set; } = string.Empty;

    [Column("user_name")]
    public string UserName { get; set; } = string.Empty;

    public UserDto? UserDto { get; set; }
}