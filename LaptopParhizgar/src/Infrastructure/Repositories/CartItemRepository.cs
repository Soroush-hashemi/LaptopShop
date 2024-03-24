using Domain.Carts;
using Domain.Carts.Repository;
using Infrastructure.Persistence;
using Infrastructure.Repositories.Base;

namespace Infrastructure.Repositories;
public class CartItemRepository : BaseRepository<CartItem>, ICartItemRepository
{
    public CartItemRepository(LaptopParhizgerContext context) : base(context)
    {
    }

    public CartItem FindByProductIdandCartId(long ProductId, long cartId)
    {
        var cartItem = _context.CartItem.Where(p => p.ProductId == ProductId && p.CartId == cartId).FirstOrDefault();
        return cartItem;
    }

    public void Remove(long cartItemId)
    {
        var orderItem = _context.CartItem.FirstOrDefault(o => o.Id == cartItemId);
        _context.Remove(orderItem);
    }
}