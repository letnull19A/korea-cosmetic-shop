using WebApplication1.DataBase.Interfaces;
using WebApplication1.DTOs;
using WebApplication1.Interfaces;

namespace WebApplication1.Commands.Favorites
{
    public class FavoritesByUserIdCommand : ICommand
    {
        private readonly IDataBaseContext _context;
        private readonly Guid _userId;
        private List<CategoryAndProductDto> _readyList;

        public FavoritesByUserIdCommand(IDataBaseContext context, Guid userId)
        {
            _context = context;
            _userId = userId;
            _readyList = new();
        }

        public List<CategoryAndProductDto> ReadyList { get => _readyList; set => _readyList = value; }

        public void Execute()
        {
            _readyList = _context
                .Favorites
                .Where(t => t.UserId == _userId)
                .Join(
                    _context.Products,
                    u => u.ProductId,
                    v => v.Id,
                    (u, v) => v
                ).Join(_context.Categories,
                    u => u.CategoryId,
                    v => v.CategoryId,
                    (u, v) => new CategoryAndProductDto()
                    {
                        ProductId = u.Id,
                        ProductName = u.Name,
                        CategoryName = v.Name
                    }
                ).ToList();
        }
    }
}
