using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Commands.Favorites;
using WebApplication1.DataBase.Interfaces;
using WebApplication1.DTOs;
using WebApplication1.Models.DTOs;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class AuthenticatedController : Controller
    {
        private readonly IDataBaseContext _context;
        
        public AuthenticatedController(IDataBaseContext context) 
            => (_context) = (context);
        
        public IActionResult Profile()
        {
            var userId = Guid.Parse(HttpContext.User.FindFirst("id")?.Value);

            var command = new FavoritesByUserIdCommand(_context, userId);

            command.Execute();

            var data = new AuthenticatedDto() 
            {
                Favorites = command.ReadyList,
                User = new UserDto() 
                {
                    Login = HttpContext.User.FindFirst("login")?.Value,
                    Name = HttpContext.User.FindFirst("name")?.Value,
                    Surname = HttpContext.User.FindFirst("surname")?.Value,
                    FatherName = HttpContext.User.FindFirst("fatherName")?.Value,
                    Email = HttpContext.User.FindFirst("email")?.Value,
                    Phone = HttpContext.User.FindFirst("phone")?.Value,
                }
            };

            return View(data);
        }

        public async Task<IActionResult> Logout() 
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}