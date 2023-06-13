using WebApplication1.DataBase.Interfaces;
using WebApplication1.Interfaces;

namespace WebApplication1.Commands.Basket
{
    public class DeleteProductFromBasket : ICommand
    {

        private readonly IDataBaseContext _context;
        private Guid _productId;
        private Guid _userId;

        public DeleteProductFromBasket(IDataBaseContext context, Guid productId, Guid userId)
            => (_context, _userId, _productId) = (context, userId, productId);

        public void Execute()
        {
            var basketItem = _context
                .Baskets
                .FirstOrDefault(t => 
                    t.ProductId == _productId && 
                    t.UserId == _userId);

            _context.Baskets.Remove(basketItem);

            _context.SaveAsync();
        }
    }
}
