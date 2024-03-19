using Common.Query;
using Query.Products.DTOs;

namespace Query.Products.GetByFilter;
public class GetProductsByFilterQuery : IQuery<ProductFilterDto>
{
    public GetProductsByFilterQuery(int pageCount, List<ProductDto> posts, ProductFilterParams filterParams)
    {
        PageCount = pageCount;
        Posts = posts;
        FilterParams = filterParams;
    }

    public int PageCount { get; set; }
    public List<ProductDto> Posts { get; set; }
    public ProductFilterParams FilterParams { get; set; }
}