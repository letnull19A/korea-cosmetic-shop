using WebApplication1.Models.DTOs;

namespace WebApplication1.DTOs
{
    public sealed class AuthenticatedDto
    {
        public UserDto User { get; set; }
        public List<CategoryAndProductDto> Favorites { get; set; }
    }
}
