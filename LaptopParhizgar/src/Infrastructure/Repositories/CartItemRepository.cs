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
        throw new NotImplementedException();
    }

    public void Remove(long cartItemId)
    {
        throw new NotImplementedException();
    }
}