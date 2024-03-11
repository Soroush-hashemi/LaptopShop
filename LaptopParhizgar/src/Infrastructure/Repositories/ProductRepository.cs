using Domain.Carts;
using Domain.Products;
using Domain.Products.Repository;
using Infrastructure.Persistence;
using Infrastructure.Repositories.Base;

namespace Infrastructure.Repositories;
public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(LaptopParhizgerContext context) : base(context)
    {

    }

    public void DeleteCartItem(CartItem cartItem)
    {
        _context.CartItem.Remove(cartItem);
    }

    public void DeleteProduct(Product product)
    {
        _context.Products.Remove(product);
    }

    public List<CartItem> GetCartsByProductId(long productId)
    {
        return _context.CartItem.Where(c => c.ProductId == productId).ToList();
    }
}