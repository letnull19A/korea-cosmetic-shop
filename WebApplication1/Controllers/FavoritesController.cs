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

        /// <summary>
        /// Добавление товара в избранное
        /// </summary>
        /// <param name="productId">ID товара</param>
        /// <returns>IActionResult</returns>
        [HttpPut]
        public async Task<IActionResult> Add(Guid productId) 
        {
            // Получение ID пользователя
            var userId = Guid.Parse(HttpContext.User.FindFirst("id")?.Value);

            // находим товар в списке избранного у пользователя
            var favInList = _context
                    .Favorites
                    .FirstOrDefault(
                        y => y.UserId == userId &&
                        y.ProductId == productId);

            // если товар найден в списке то удаляем его
            // иначе товар добавляется в список
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

            // сохранение изменений
            await _context.SaveAsync();

            // возвращяем статус 200
            return Ok();
        }

        /// <summary>
        /// Получение избранных товаров
        /// </summary>
        /// <returns>IActionResult</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Получаем ID пользователя
            var userId = Guid.Parse(HttpContext.User.FindFirst("id")?.Value);
            // Получаем товары добавленные в избранное, за это
            // отвечает класс FavoritesByUserIdCommand
            var command = new FavoritesByUserIdCommand(_context, userId);

            // Выполняем команду
            command.Execute();

            // Возвращаем список избранных товаров пользователя
            return Ok(command.ReadyList);
        }
    }
}
