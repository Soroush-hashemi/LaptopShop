using Query.Products.DTOs;

namespace PresentationFacade.Products.Serivce;
public interface IProductSerivce
{
    ProductFilterDto GetProductByFilter(ProductFilterParams filterParams);
    List<ProductDto> GetRelatedProducts(long CategoryId);
    List<ProductDto> GetPopularProduct();
    List<ProductDto> GetLastesProduct();
}