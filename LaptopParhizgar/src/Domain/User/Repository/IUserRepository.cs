using Common.Domain.Repository;
using Domain.Address;
using Domain.Carts;
using Domain.Payment;
using Domain.Products;

namespace Domain.Users.Repository;
public interface IUserRepository : IBaseRepository<User>
{
    void DeleteAddress(Addresses item);
    void DeleteComment(ProductComment item);
    void DeleteRequestPay(RequestPay item);
    void DeleteUser(User User);
    void DeleteCart(Cart cart);
    void DeleteCartItem(CartItem cartItem);
    public Addresses GetAddressByUserId(long UserId);
    public List<Cart> GetCartsByUserId(long UserId);
    public List<ProductComment> GetCommentByUserId(long UserId);
    public List<RequestPay> GetRequestPayByUserId(long UserId);
    public List<CartItem> GetByCartId(long CartId);
}