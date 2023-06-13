using WebApplication1.DataBase.Interfaces;
using WebApplication1.Interfaces;
using WebApplication1.Models.DTOs;

namespace WebApplication1.Commands.Categories;

public sealed class AllCategoryCommand : ICommand
{
    private readonly IDataBaseContext _context;
    private List<CategoryDto> _readyList;

    public AllCategoryCommand(IDataBaseContext context)
        => (_context) = (context);

    public List<CategoryDto> ReadyList
    { 
        get => _readyList; 
        set => _readyList = value; 
    }

    public void Execute()
    {
        _readyList = _context.Categories.ToList();
    }
}