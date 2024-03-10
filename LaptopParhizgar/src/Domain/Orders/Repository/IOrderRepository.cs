using Common.Domain.Repository;
using Domain.Carts;
using Domain.Payment;
using Domain.Products;

namespace Domain.Orders.Repository;
public interface IOrderRepository : IBaseRepository<Order>
{
    public RequestPay FindRequestPayById(long Id);
    public Cart FindCartsById(long Id);
    public List<CartItem> FindCartItemListByCartId(long Id); // Where(p => p.CartId == cart.Id).ToList();
    public Product FindProductById(long Id);
}