using Domain.Carts;
using Domain.Orders;
using Domain.Orders.Repository;
using Domain.Payment;
using Domain.Products;
using Infrastructure.Persistence;
using Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class OrderRepository : BaseRepository<Order>, IOrderRepository
{
    public OrderRepository(LaptopParhizgerContext context) : base(context)
    {
    }

    public List<CartItem> FindCartItemListByCartId(long Id)
    {
        return _context.CartItem.Where(c => c.CartId == Id).ToList();
    }

    public Cart FindCartsById(long Id)
    {
        return _context.Carts.FirstOrDefault(c => c.Id == Id);
    }

    public Product FindProductById(long Id)
    {
        return _context.Products.FirstOrDefault(c => c.Id == Id);
    }

    public RequestPay FindRequestPayById(long Id)
    {
        return _context.RequestPay.FirstOrDefault(c => c.Id == Id);
    }
}