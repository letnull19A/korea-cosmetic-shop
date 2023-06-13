namespace WebApplication1.DTOs;

public class UpdateUserDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string FatherName { get; set; }
    public string Login { get; set; }
    public string Email { get; set; }
}