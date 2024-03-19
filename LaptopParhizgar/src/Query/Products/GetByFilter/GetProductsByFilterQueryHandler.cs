using Common.Query;
using Infrastructure.Persistence;
using Query.Products.DTOs;

namespace Query.Products.GetByFilter;
public class GetProductsByFilterQueryHandler : IQueryHandler<GetProductsByFilterQuery, ProductFilterDto>
{
    private readonly LaptopParhizgerContext _context;
    public GetProductsByFilterQueryHandler(LaptopParhizgerContext context)
    {
        _context = context;
    }

    public async Task<ProductFilterDto> Handle(GetProductsByFilterQuery request, CancellationToken cancellationToken)
    {
        var result = _context.Products.OrderByDescending(p => p.Id).AsEnumerable();

        if (!string.IsNullOrWhiteSpace(request.FilterParams.Title))
            result = result.Where(r => r.Title.Contains(request.FilterParams.Title));

        if (!string.IsNullOrWhiteSpace(request.FilterParams.CategorySlug))
            result = result.Where(r => r.Title.Contains(request.FilterParams.CategorySlug));

        var skip = (request.FilterParams.PageId - 1) * request.FilterParams.Take;
        var model = new ProductFilterDto()
        {
            FilterParams = request.FilterParams,
            Product = result.Skip(skip).Take(request.FilterParams.Take)
                .Select(post => ProductMapper.Map(post)).ToList(),
        };

        model.GeneratePaging(result, request.FilterParams.Take, request.FilterParams.PageId);

        return model;
    }
}