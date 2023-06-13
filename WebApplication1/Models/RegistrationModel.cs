using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public sealed class RegistrationModel
{
    [Required(ErrorMessage = "Поле не может быть пустым")]
    public string Name { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Поле не может быть пустым")]
    public string Surname { get; set; } = string.Empty;
    
    public string? FatherName { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Поле не может быть пустым")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Поле не может быть пустым")]
    public string Phone { get; set; } = string.Empty;

    [Required(ErrorMessage = "Поле не может быть пустым")]
    public string Login { get; set; } = string.Empty;

    [Required(ErrorMessage = "Поле не может быть пустым")]
    public string Password { get; set; } = string.Empty;

    [Required(ErrorMessage = "Поле не может быть пустым")]
    public string ConfirmPassword { get; set; } = string.Empty;
}