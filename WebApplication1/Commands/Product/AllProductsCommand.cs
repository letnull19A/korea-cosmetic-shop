using Mapster;
using WebApplication1.DataBase.Interfaces;
using WebApplication1.DTOs;
using WebApplication1.Interfaces;

namespace WebApplication1.Commands.Categories;

public sealed class AllProductCommand : ICommand
{
    private readonly IDataBaseContext _context;
    private List<ProductForViewDto> _readyList;

    public AllProductCommand(IDataBaseContext context)
        => (_context, _readyList) = (context, new List<ProductForViewDto>());

    public List<ProductForViewDto> ReadyList
    {
        get => _readyList;
        set => _readyList = value;
    }

    public void Execute()
    {
        _context
            .Products
            .ToList()
            .ForEach(product =>
        {
            string category = _context
                .Categories
                .FirstOrDefault(c => c.CategoryId == product.CategoryId)?
                .Name ?? string.Empty;

            var current = product.Adapt<ProductForViewDto>();
            current.Caregory = category;

            _readyList.Add(current);
        });
    }
}