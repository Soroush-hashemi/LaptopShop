using Domain.Category;
using Domain.Category.Repository;
using Infrastructure.Persistence;
using Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(LaptopParhizgerContext context) : base(context)
    {
    }

    public bool DeleteCategory(long categoryId)
    {
        var category = _context.Categories.Include(c => c.Childs).FirstOrDefault(c => c.Id.Equals(categoryId));

        if (category == null)
            return false;

        var hasPostInCategory = _context.Products
            .Any(c => c.CategoryId == categoryId || c.SubCategoryId == categoryId); // اگر این 0 بشود 1 برای ما برگشت داده میشود

        if (hasPostInCategory) // اگر پستی بر روی این کتگوری نوشته شده بود مقدار 0 را برای ما برگشت میزند
            return false;

        if (category.Childs.Count() > 0)
        {
            _context.RemoveRange(category.Childs);
        }
        _context.RemoveRange(category);

        return true;
    }
}