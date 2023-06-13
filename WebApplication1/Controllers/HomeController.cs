using System.Diagnostics;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DataBase.Interfaces;
using WebApplication1.DTOs;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IDataBaseContext _context;

    public HomeController(ILogger<HomeController> logger, IDataBaseContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> AdminMenu()
    {
        return PartialView("_AdminMenu");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    
    public async Task<IActionResult> Index()
    {
        var userId = Guid.Parse(HttpContext.User?.FindFirst("id")?.Value ?? Guid.NewGuid().ToString());

        var products = _context
            .Products
            .ToList()
            .Adapt<List<ProductsWithFavDto>>();

        products.ForEach(p => 
        {
            p.IsFavorite = _context
            .Favorites
            .Any(
                e => e.UserId == userId && 
                e.ProductId == p.Id);
        });

        var model = new ProductsListModel()
        {
            Products = _context.Products.ToList(),
            ProductsWithFavs = products,

        };
        
        return View(model);
    }
}