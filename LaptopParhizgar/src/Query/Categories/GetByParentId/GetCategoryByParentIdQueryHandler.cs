using Microsoft.EntityFrameworkCore;
using Query.Categories.DTOs;
using Common.Query;
using Infrastructure.Persistence;

namespace Query.Categories.GetByParentId;
public class GetCategoryByParentIdQueryHandler : IQueryHandler<GetCategoryByParentIdQuery, List<SubCategoryDto>>
{
    private readonly LaptopParhizgerContext _context;
    public GetCategoryByParentIdQueryHandler(LaptopParhizgerContext context)
    {
        _context = context;
    }

    public async Task<List<SubCategoryDto>> Handle(GetCategoryByParentIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Categories.Include(c => c.Childs).Where(c => c.ParentId == request.ParentId).ToListAsync();
        return result.MapSubCategory();
    }
}