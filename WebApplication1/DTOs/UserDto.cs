using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models.DTOs;

[Table("users")]
public sealed class UserDto
{
    [Key] 
    [Column("id")] 
    public Guid Id { get; set; } = Guid.NewGuid();

    [Column("role_id")]
    public Guid RoleId { get; set; }

    [Column("name")] 
    public string Name { get; set; } = string.Empty;

    [Column("surname")] 
    public string Surname { get; set; } = string.Empty;

    [Column("fatherName")]
    public string? FatherName { get; set; } = string.Empty;

    [Column("login")]
    public string Login { get; set; } = string.Empty;

    [Column("email")]
    public string Email { get; set; } = string.Empty;
    
    [Column("password")]
    public string Password { get; set; } = string.Empty;
    
    [Column("phone")]
    public string Phone { get; set; } = string.Empty;

    public ICollection<PaymentMeanDto>? PaymentMeanDtos { get; set; }
    public ICollection<FavoriteDto>? FavoriteDtos { get; set; }
    public RoleDto? Role { get; set; }
}