using Microsoft.AspNetCore.Mvc;
using WebApplication1.DataBase.Interfaces;

namespace WebApplication1.Controllers
{
    public class UsersController : Controller
    {
        private readonly IDataBaseContext _context;

        public UsersController(IDataBaseContext context)
            => (_context) = (context);

        public IActionResult All()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() 
        {
            return Ok(_context.Users.ToList());
        }
    }
}
