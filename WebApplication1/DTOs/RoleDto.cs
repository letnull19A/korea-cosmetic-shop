using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models.DTOs
{
    [Table("roles")]
    public sealed class RoleDto
    {
        [Key]
        [Column("id")]
        [Required]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Column("name")]
        [Required]
        public string Name { get; set; } = string.Empty;

        [Column("backend_name")]
        [Required]
        public string BackendName { get; set; } = string.Empty;

        public ICollection<UserDto>? Users { get; set; }
    }
}
