using Microsoft.EntityFrameworkCore;
using Common.Query;
using Infrastructure.Persistence;
using Query.Categories.DTOs;

namespace Query.Categories.GetById;
public class GetCategoryByIdQueryHandler : IQueryHandler<GetCategoryByIdQuery, CategoryDto>
{
    private readonly LaptopParhizgerContext _context;
    public GetCategoryByIdQueryHandler(LaptopParhizgerContext context)
    {
        _context = context;
    }

    public async Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var category = await _context.Categories.Include(c => c.Childs).FirstOrDefaultAsync(c => c.Id == request.CategoryId, cancellationToken);
        if (category == null)
            return null;

        return category.Map();
    }
}