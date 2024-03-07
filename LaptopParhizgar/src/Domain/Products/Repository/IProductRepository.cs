using Common.Domain.Repository;

namespace Domain.Products.Repository;
public interface IProductRepository : IBaseRepository<Product>
{
    void DeleteProduct(Product product);
}