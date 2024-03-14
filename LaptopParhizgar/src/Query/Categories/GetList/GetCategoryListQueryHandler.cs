using Microsoft.EntityFrameworkCore;
using Query.Categories.DTOs;
using Common.Query;
using Infrastructure.Persistence;

namespace Query.Categories.GetList;
public class GetCategoryListQueryHandler : IQueryHandler<GetCategoryListQuery, List<CategoryDto>>
{
    private readonly LaptopParhizgerContext _context;
    public GetCategoryListQueryHandler(LaptopParhizgerContext context)
    {
        _context = context;
    }

    public async Task<List<CategoryDto>> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
    {
        var result = _context.Categories.Include(c => c.Childs).OrderByDescending(c => c.Id).ToList();

        return result.MapList();
    }
}