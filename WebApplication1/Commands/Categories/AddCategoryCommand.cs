using WebApplication1.DataBase.Interfaces;
using WebApplication1.Interfaces;
using WebApplication1.Models.DTOs;

namespace WebApplication1.Commands.Categories;

public sealed class AddCategoryCommand : ICommand
{
    private readonly CategoryDto _category;
    private readonly IDataBaseContext _context;

    public AddCategoryCommand(CategoryDto category, IDataBaseContext context) 
        => (_category, _context) = (category, context);

    public void Execute()
    {
        if (_context == null)
            throw new NullReferenceException(nameof(_context));

        _context.Categories.Add(_category);
        
        _context.SaveAsync();
    }
}