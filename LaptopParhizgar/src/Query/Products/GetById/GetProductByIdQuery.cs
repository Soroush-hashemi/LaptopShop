using Common.Query;
using Query.Products.DTOs;

namespace Query.Products.GetById;
public record GetProductByIdQuery(long productId) : IQuery<ProductDto>;