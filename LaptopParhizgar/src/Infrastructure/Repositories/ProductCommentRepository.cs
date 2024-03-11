using Domain.Products;
using Domain.Products.Repository;
using Infrastructure.Persistence;
using Infrastructure.Repositories.Base;

namespace Infrastructure.Repositories;
public class ProductCommentRepository : BaseRepository<ProductComment>, IProductCommentRepository
{
    public ProductCommentRepository(LaptopParhizgerContext context) : base(context)
    {
    }

    public void DeleteProductComment(ProductComment productComment)
    {
        _context.ProductComments.Remove(productComment);
        _context.SaveChanges();
    }

    public List<ProductComment> GetByProductId(long Id)
    {
        return _context.ProductComments.Where(c => c.ProductId == Id).ToList();
    }
}