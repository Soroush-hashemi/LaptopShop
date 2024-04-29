using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Query.Products;
using Query.Products.DTOs;

namespace PresentationFacade.Products.Serivce;
public class ProductSerivce : IProductSerivce
{
    private readonly LaptopParhizgerContext _context;
    public ProductSerivce(LaptopParhizgerContext context)
    {
        _context = context;
    }

    public List<ProductDto> GetPopularProduct()
    {
        return _context.Products
                .OrderByDescending(v => v.Visit)
                .Take(10).Select(product => ProductMapper.Map(product)).ToList();
    }

    public List<ProductDto> GetLastesProduct()
    {
        return _context.Products
                .OrderByDescending(t => t.CreationDate)
                .Take(10).Select(product => ProductMapper.Map(product)).ToList();
    }


    public ProductFilterDto GetProductByFilter(ProductFilterParams filterParams)
    {
        var category = _context.Categories.FirstOrDefault(s => s.Slug == filterParams.CategorySlug);
        if (category != null)
        {
            var post = _context.Products.Where(c => c.CategoryId == category.Id || c.SubCategoryId == category.Id)
                .OrderByDescending(d => d.CreationDate).ToList();

            var skip = (filterParams.PageId - 1) * filterParams.Take;
            var model = new ProductFilterDto()
            {
                Product = post.Skip(skip).Take(filterParams.Take)
                    .Select(post => post.Map()).ToList(),
                FilterParams = filterParams,
            };
            model.GeneratePaging(post, filterParams.Take, filterParams.PageId);
            return model;
        }
        else
        {
            var post = _context.Products.OrderByDescending(d => d.CreationDate).AsQueryable();

            if (!string.IsNullOrWhiteSpace(filterParams.Title))
                post = post.Where(r => r.Title.Contains(filterParams.Title));

            var skip = (filterParams.PageId - 1) * filterParams.Take;
            var model = new ProductFilterDto()
            {
                Product = post.Skip(skip).Take(filterParams.Take)
                    .Select(post => post.Map()).ToList(),
                FilterParams = filterParams,
            };
            model.GeneratePaging(post, filterParams.Take, filterParams.PageId);
            return model;
        }
    }

    public List<ProductDto> GetRelatedProducts(long CategoryId)
    {
        return _context.Products
            .Where(r => r.CategoryId == CategoryId || r.SubCategoryId == CategoryId)
            .OrderByDescending(d => d.CreationDate)
            .Take(6).Select(Product => ProductMapper.Map(Product)).ToList();
    }
}