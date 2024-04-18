using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PresentationFacade.Products.Serivce;
using Query.Products.DTOs;

namespace WebApplication.Pages;
public class SearchModel : PageModel
{
    private readonly IProductSerivce _productSerivce;
    public SearchModel(IProductSerivce productSerivce)
    {
        _productSerivce = productSerivce;
    }
    public ProductFilterDto? Filter { get; set; }

    public void OnGet(int pageId = 1, string categorySlug = null, string q = null)
    {
        Filter = _productSerivce.GetProductByFilter(new ProductFilterParams()
        {
            CategorySlug = categorySlug,
            PageId = pageId,
            Take = 16,
            Title = q
        });
    }

    public IActionResult OnGetPagination(int pageId = 1, string categorySlug = null, string q = null)
    {
        var Model = _productSerivce.GetProductByFilter(new ProductFilterParams()
        {
            CategorySlug = categorySlug,
            PageId = pageId,
            Take = 16,
            Title = q
        });
        return Partial("_SearchView", Model);
    }
}