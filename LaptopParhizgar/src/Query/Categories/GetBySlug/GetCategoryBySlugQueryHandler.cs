using Common.Query;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Query.Categories.DTOs;

namespace Query.Categories.GetBySlug;
public class GetCategoryBySlugQueryHandler : IQueryHandler<GetCategoryBySlugQuery, CategoryDto>
{
    private readonly LaptopParhizgerContext _context;
    public GetCategoryBySlugQueryHandler(LaptopParhizgerContext context)
    {
        _context = context;
    }

    public async Task<CategoryDto> Handle(GetCategoryBySlugQuery request, CancellationToken cancellationToken)
    {
        var category = await _context.Categories.FirstOrDefaultAsync(c => c.Slug == request.slug, cancellationToken);
        if (category == null)
            return null;

        return category.Map();
    }
}