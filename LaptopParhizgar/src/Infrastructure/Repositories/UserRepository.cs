using Domain.Addresses;
using Domain.Carts;
using Domain.Payment;
using Domain.Products;
using Domain.Users;
using Domain.Users.Repository;
using Infrastructure.Persistence;
using Infrastructure.Repositories.Base;

namespace Infrastructure.Repositories;
public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(LaptopParhizgerContext context) : base(context)
    {

    }

    public void DeleteAddress(Address addresses)
    {
        _context.Addresses.Remove(addresses);
    }

    public void DeleteCart(Cart cart)
    {
        _context.Carts.Remove(cart);
    }

    public void DeleteCartItem(CartItem cartItem)
    {
        _context.CartItem.Remove(cartItem);
    }

    public void DeleteComment(ProductComment comment)
    {
        _context.ProductComments.Remove(comment);
    }

    public void DeleteRequestPay(RequestPay requestPay)
    {
        _context.RequestPay.Remove(requestPay);
    }

    public void DeleteUser(User User)
    {
        _context.Users.Remove(User);
    }

    public Address GetAddressByUserId(long UserId)
    {
        return _context.Addresses.FirstOrDefault(a => a.UserId == UserId);
    }

    public List<CartItem> GetByCartId(long CartId)
    {
        return _context.CartItem.Where(c => c.Id == CartId).ToList();
    }

    public List<Cart> GetCartsByUserId(long UserId)
    {
        return _context.Carts.Where(c => c.Id == UserId).ToList();
    }

    public List<ProductComment> GetCommentByUserId(long UserId)
    {
        return _context.ProductComments.Where(c => c.Id == UserId).ToList();
    }

    public List<RequestPay> GetRequestPayByUserId(long UserId)
    {
        return _context.RequestPay.Where(c => c.Id == UserId).ToList();
    }
}
