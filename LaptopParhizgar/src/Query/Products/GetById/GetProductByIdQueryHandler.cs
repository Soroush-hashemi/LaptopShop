using Common.Query;
using Infrastructure.Persistence;
using Query.Products.DTOs;

namespace Query.Products.GetById;
public class GetProductByIdQueryHandler : IQueryHandler<GetProductByIdQuery, ProductDto>
{
    private readonly LaptopParhizgerContext _context;
    public GetProductByIdQueryHandler(LaptopParhizgerContext context)
    {
        _context = context;
    }

    public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = _context.Products.FirstOrDefault(p => p.Id == request.productId);
        if (product == null)
            return null;

        return product.Map();
    }
}