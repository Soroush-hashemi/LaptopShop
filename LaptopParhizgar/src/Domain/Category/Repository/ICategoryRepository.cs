using Common.Domain.Repository;

namespace Domain.Category.Repository;
public interface ICategoryRepository : IBaseRepository<Category>
{
    public Task<bool> DeleteCategory(long categoryId);
}