using Common.Domain.Repository;

namespace Domain.Category.Repository;
public interface ICategoryRepository : IBaseRepository<Category>
{
    bool DeleteCategory(long categoryId);
}