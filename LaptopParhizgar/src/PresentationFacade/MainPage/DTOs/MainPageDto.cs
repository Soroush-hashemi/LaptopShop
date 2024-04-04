using Query.Products.DTOs;

namespace PresentationFacade.MainPage.DTOs;
public class MainPageDto
{
    public List<ProductDto> SpecialProducts { get; set; }
    public List<ProductDto> AdminSuggestion { get; set; }
    public List<ProductDto> DiscountedPrice { get; set; }
    public List<ProductDto> BigTable { get; set; }
}