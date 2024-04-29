using Common.Domain.Repository;

namespace Domain.Carts.Repository;
public interface ICartItemRepository : IBaseRepository<CartItem>
{
    public CartItem FindByProductIdandCartId(long ProductId , long cartId); // Where(p => p.ProductId == ProductId && p.CartId == cart.Id).FirstOrDefault();
    public void Remove(CartItem cartItem);
}