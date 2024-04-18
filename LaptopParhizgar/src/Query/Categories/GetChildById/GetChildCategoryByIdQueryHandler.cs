using Common.Query;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Query.Categories.DTOs;

namespace Query.Categories.GetChildById;
public class GetChildCategoryByIdQueryHandler : IQueryHandler<GetChildCategoryByIdQuery, SubCategoryDto>
{
    private readonly LaptopParhizgerContext _context;
    public GetChildCategoryByIdQueryHandler(LaptopParhizgerContext context)
    {
        _context = context;
    }

    public async Task<SubCategoryDto> Handle(GetChildCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var Subcategory = await _context.Categories.FirstOrDefaultAsync(c => c.Id == request.subCategoryId, cancellationToken);
        if (Subcategory == null)
            return null;

        return Subcategory.SubMap();
    }
}