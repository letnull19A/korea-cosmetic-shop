using Mapster;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DataBase.Interfaces;
using WebApplication1.DTOs;
using WebApplication1.Models.DTOs;

namespace WebApplication1.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IDataBaseContext _context;

        public ReviewController(IDataBaseContext context)
            => (_context) = (context);

        [HttpPut]
        public async Task<IActionResult> Add(AddReviewDto review)
        {
            var userId = Guid.Parse(HttpContext.User.FindFirst("id")?.Value);

            var current = review.Adapt<ReviewDto>();
            current.UserId = userId;

            _context
                .Reviews
                .Add(current);

            await _context.SaveAsync();

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get(Guid productId)
        {
            var reviews = _context
                .Reviews
                .Where(s => s.ProductId == productId)
                .ToList();

            var readyReviews = reviews
                .Join(
                    _context.Users, 
                    u => u.UserId, 
                    v => v.Id, 
                    (u, v) => new ReviewForViewDto()
                    {
                        Name = v.Name,
                        Surname = v.Surname,
                        Message = u.Message
                    }).ToList();

            return Ok(readyReviews);
        }
    }
}