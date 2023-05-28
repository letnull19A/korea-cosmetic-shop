using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApplication1.Commands.Favorites;
using WebApplication1.DataBase.Interfaces;
using WebApplication1.Models.DTOs;

namespace WebApplication1.Controllers
{
    public class FavoritesController : Controller
    {
        private readonly IDataBaseContext _context;

        public FavoritesController(IDataBaseContext context)
            => (_context) = (context);

        [HttpPut]
        public async Task<IActionResult> Add(Guid productId) 
        {
            //TODO: Сделать проверку есть ли уже в избранном что-то
            //TODO: если есть то удалить иначе добавить в бд

            var userId = Guid.Parse(HttpContext.User.FindFirst("id")?.Value);

            var favInList = _context
                    .Favorites
                    .FirstOrDefault(
                        y => y.UserId == userId &&
                        y.ProductId == productId);

            if (favInList != null) 
            {
                _context
                    .Favorites
                    .Remove(favInList);
            } else
            {
                _context.Favorites.Add(new FavoriteDto() 
                {
                    UserId = userId,
                    ProductId = productId
                });
            }

            await _context.SaveAsync();

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var userId = Guid.Parse(HttpContext.User.FindFirst("id")?.Value);
            var command = new FavoritesByUserIdCommand(_context, userId);

            command.Execute();

            return Ok(command.ReadyList);
        }
    }
}
