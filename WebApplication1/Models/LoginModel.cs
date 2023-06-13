using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public sealed class LoginModel
{
    [Required(ErrorMessage = "Поле не может быть пустым")]
    public string Login { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Поле не может быть пустым")]
    public string Password { get; set; } = string.Empty;
}