using Common.Domain.Repository;

namespace Domain.Products.Repository;
public interface IProductCommentRepository : IBaseRepository<ProductComment>
{
    public void DeleteProductComment(ProductComment productComment);
    public List<ProductComment> GetByProductId(long Id);
}