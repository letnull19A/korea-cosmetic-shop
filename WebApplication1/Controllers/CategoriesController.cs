using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DataBase.Interfaces;
using WebApplication1.Models.DTOs;
using WebApplication1.Commands.Categories;
using WebApplication1.DTOs;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IDataBaseContext _context;
    
        public CategoriesController(IDataBaseContext context) 
            => (_context) = (context);

        [Authorize(Roles = "admin")]
        public IActionResult Add()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        public IActionResult Delete(CategoryDto category) 
        {
            _context.Categories.Remove(category);

            return All();
        }

        public IActionResult All()
        {
            var gettingListCommand = new AllCategoryCommand(_context);
            gettingListCommand.Execute();

            return View(gettingListCommand.ReadyList);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Add(AddCategoryDto addCategory)
        {
            var addCategoryCommand = new AddCategoryCommand(
                addCategory.Adapt<CategoryDto>(), 
                _context);

            addCategoryCommand.Execute();
            
            return Add();
        }

        [HttpGet]
        public async Task<List<CategoryDto>> GetAll()
        {
            return await _context
                .Categories.ToListAsync();
        }

        [HttpPut]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Update(CategoryDto category) 
        {
            var forUpdate = _context
                .Categories
                .FirstOrDefault(c => c.CategoryId == category.CategoryId);

            if (forUpdate == null)
                return NotFound();

            forUpdate.Name = category.Name;

            await _context.SaveAsync();

            return Ok();
        }

        [HttpDelete]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(Guid id) 
        {
            _context
                .Categories
                .Remove(_context
                    .Categories
                    .First(i => i.CategoryId == id));

            await _context.SaveAsync();

            return Ok();
        }

        public async Task<IActionResult> GetAllPartial() 
        {
            return PartialView("_Menu", await GetAll());
        }

        public IActionResult Get(Guid id)
        {
            var selected = new SelectedCategoryModel();
            selected.Category = _context.Categories.First(r => r.CategoryId == id).Name;
            selected.Products = _context.Products.Where(t => t.CategoryId == id).ToList();
            
            var userId = Guid.Parse(HttpContext.User?.FindFirst("id")?.Value ?? Guid.NewGuid().ToString());

            var products = selected
                .Products
                .Adapt<List<ProductsWithFavDto>>();

            products.ForEach(p => 
            {
                p.IsFavorite = _context
                    .Favorites
                    .Any(
                        e => e.UserId == userId && 
                             e.ProductId == p.Id);
            });

            selected.ProductsWithFavs = products;

            return View(selected);
        }
    }
}

//TODO: добавить оформление заказа