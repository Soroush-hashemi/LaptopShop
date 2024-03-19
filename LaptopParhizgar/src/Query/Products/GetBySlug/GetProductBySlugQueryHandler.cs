using Common.Query;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Query.Products.DTOs;

namespace Query.Products.GetBySlug;
public class GetProductBySlugQueryHandler : IQueryHandler<GetProductBySlugQuery, ProductDto>
{
    private readonly LaptopParhizgerContext _context;
    public GetProductBySlugQueryHandler(LaptopParhizgerContext context)
    {
        _context = context;
    }

    public async Task<ProductDto> Handle(GetProductBySlugQuery request, CancellationToken cancellationToken)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Slug == request.slug);
        if (product == null)
            return null;

        return product.Map();
    }
}