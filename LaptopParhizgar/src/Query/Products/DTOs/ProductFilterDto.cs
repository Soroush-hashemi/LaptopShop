using Query.Sheard;

namespace Query.Products.DTOs;
public class ProductFilterDto : BasePagination
{
    public List<ProductDto> Product { get; set; }
    public ProductFilterParams FilterParams { get; set; }
}

public class ProductFilterParams
{
    public string Title { get; set; }
    public string CategorySlug { get; set; }
    public int PageId { get; set; }
    public int Take { get; set; }
}