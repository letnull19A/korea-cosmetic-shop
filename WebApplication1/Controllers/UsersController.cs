using Microsoft.AspNetCore.Mvc;
using WebApplication1.DataBase.Interfaces;
using WebApplication1.DTOs;

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

        [HttpPut]
        public async Task<IActionResult> Update(UpdateUserDto data)
        {

            var user = _context.Users.Where(u => u.Id == data.Id).FirstOrDefault();

            if (user == null)
            {
                return NotFound();
            }

            user.Email = data.Email;
            user.Login = data.Login;
            user.Name = data.Name;
            user.Surname = data.Surname;
            user.FatherName = data.FatherName;

            await _context.SaveAsync();
            
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var user = _context.Users.Where(u => u.Id == id).FirstOrDefault();
            
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            
            await _context.SaveAsync();
            
            return Ok();
        }
    }
}
