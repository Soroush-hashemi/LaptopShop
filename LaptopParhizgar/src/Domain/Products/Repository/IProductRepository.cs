using Common.Domain.Repository;
using Domain.Carts;

namespace Domain.Products.Repository;
public interface IProductRepository : IBaseRepository<Product>
{
    void DeleteProduct(Product product);
    void DeleteCartItem(CartItem cartItem);
    public List<CartItem> GetCartsByProductId(long productId);
}