using Common.Domain.Repository;

namespace Domain.Category.Repository;
public interface ICategoryRepository : IBaseRepository<Category>
{
    public bool DeleteCategory(long categoryId);
}