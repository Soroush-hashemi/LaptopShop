using Infrastructure.Persistence;
using PresentationFacade.MainPage.DTOs;
using Query.Products;

namespace PresentationFacade.MainPage;
public class MainPageService : IMainPageService
{
    private readonly LaptopParhizgerContext _context;
    public MainPageService(LaptopParhizgerContext context)
    {
        _context = context;
    }

    public MainPageDto GetData()
    {
        var SpecialProduct = _context.Products
                .OrderByDescending(p => p.Id)
                .Where(s => s.IsSpecial).Take(2)
                .Select(Product => ProductMapper.Map(Product)).ToList();


        var DiscountedPrice = _context.Products
                .OrderByDescending(p => p.Id)
                .Where(s => s.DiscountedPrice != null).Take(10)
                .Select(Product => ProductMapper.Map(Product)).ToList();

        var BigTable = _context.Products
                .OrderByDescending(p => p.Id)
                .Where(s => s.BigTable).Take(1)
                .Select(Product => ProductMapper.Map(Product)).ToList();

        var AdminSuggestion = _context.Products
                .OrderByDescending(p => p.Id)
                .Where(s => s.AdminSuggestion).Take(9)
                .Select(Product => ProductMapper.Map(Product)).ToList();


        return new MainPageDto()
        {
            DiscountedPrice = DiscountedPrice,
            AdminSuggestion = AdminSuggestion,
            BigTable = BigTable,
            SpecialProducts = SpecialProduct
        };
    }
}