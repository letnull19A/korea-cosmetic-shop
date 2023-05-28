using Mapster;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Commands.Basket;
using WebApplication1.DataBase.Interfaces;
using WebApplication1.DTOs;

namespace WebApplication1.Controllers
{
    public class BasketController : Controller
    {
        private readonly IDataBaseContext _context;

        public BasketController(IDataBaseContext context)
            => (_context) = (context);

        [HttpPut]
        public async Task<IActionResult> Add(Guid productId) 
        {
            var userId = Guid.Parse(HttpContext.User.FindFirst("id")?.Value);

            var isProductInBasket = _context
                .Baskets
                .Any(b => 
                    b.ProductId == productId && 
                    b.UserId == userId);

            if (isProductInBasket)
            {
                return BadRequest("Продукт уже в корзине!");
            }

            _context.Baskets.Add(new BasketDto()
            {
                ProductId = productId,
                UserId = userId,
            });

            await _context.SaveAsync();

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id) 
        {
            var userId = Guid.Parse(HttpContext.User.FindFirst("id")?.Value);

            var deleteProductCommand = new DeleteProductFromBasket(_context, id, userId);
            deleteProductCommand.Execute();

            return Ok();
        }

        public async Task<IActionResult> GetAll()
        {
            var userId = Guid.Parse(HttpContext.User.FindFirst("id")?.Value);

            var list = _context
                .Baskets
                .Where(o => o.UserId == userId)
                .Join(_context.Products,
                u => u.ProductId,
                v => v.Id,
                (u, v) => new ProductInBasketDto()
                {
                    Id = v.Id,
                    WrapperImage = v.WrapperImage,
                    Count = u.Count,
                    Name = v.Name,
                    Price = v.Price,
                    MaxCount = v.Count,
                }).ToList();

            return View(list);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Guid productId, int count) 
        {
            var productIsExist = _context
                .Baskets
                .Any(o => o.ProductId == productId);

            if (!productIsExist) 
            {
                return NotFound();
            }

            _context
                .Baskets
                .First(r => r.ProductId == productId)
                .Count = count;

            await _context.SaveAsync();

            return Ok();
        }

        [HttpGet]
        public IActionResult GetPrice() 
        {
            var userId = Guid.Parse(HttpContext.User.FindFirst("id")?.Value);

            double price = 0;

            var list = _context
                .Baskets
                .Where(o => o.UserId == userId)
                .Join(_context.Products,
                u => u.ProductId,
                v => v.Id,
                (u, v) => new ProductInBasketDto()
                {
                    Id = v.Id,
                    WrapperImage = v.WrapperImage,
                    Count = u.Count,
                    Price = v.Price,
                    Name = v.Name,
                    MaxCount = v.Count,
                }).ToList();

            list.ForEach(item => 
            {
                price += item.Count * item.Price;
            });

            return Ok(price);
        }
    }
}
