using Application.ProductComment.Create;
using Common.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PresentationFacade.Categories;
using PresentationFacade.ProductComment;
using PresentationFacade.ProductComment.Service;
using PresentationFacade.ProductComment.Service.DTO;
using PresentationFacade.Products;
using Query.Categories.DTOs;
using Query.Products.DTOs;
using Query.Products.GetBySlug;
using System.ComponentModel.DataAnnotations;
using WebApplication.Pages.Shared.Tool;

namespace WebApplication.Pages;
public class ProductModel : PageModel
{
    private readonly ICommentService _commentService;
    private readonly IProductFacade _productsFacade;
    private readonly ICategoryFacade _categoryFacade;
    private readonly IProductCommentFacade _commentFacade;
    public ProductModel(ICommentService commentService,
        IProductFacade productsFacade, ICategoryFacade categoryFacade, IProductCommentFacade commentFacade)
    {
        _commentService = commentService;
        _productsFacade = productsFacade;
        _categoryFacade = categoryFacade;
        _commentFacade = commentFacade;
    }

    #region
    public List<CategoryDto> Categories { get; set; }

    [BindProperty]
    public ProductDto Product { get; set; }
    [BindProperty]
    public CategoryDto Category { get; set; }
    [BindProperty]
    public SubCategoryDto Child { get; set; }
    [BindProperty]
    public int ProductId { get; set; }
    [Required]
    [BindProperty]
    public string Text { get; set; }
    public List<ProductCommentDto> Comments { get; set; }
    #endregion

    public async Task<IActionResult> OnGet(string slug)
    {
        Categories = await _categoryFacade.GetList();
        Product = await _productsFacade.GetBySlug(new GetProductBySlugQuery(slug));
        if (Product == null)
        {
            return NotFound();
        }
        Category = await _categoryFacade.GetById(Product.CategoryId);
        Child = await _categoryFacade.GetChildById(Product.SubCategoryId);

        Comments = _commentService.GetProductComments(Product.Id);
        await _productsFacade.IncreaseVisit(Product.Id);
        return Page();
    }

    public async Task<IActionResult> OnPost(string slug)
    {
        if (!User.Identity.IsAuthenticated)
            return RedirectToPage("Product", new { slug });

        long userId = User.GetUserId();

        var result = await _commentFacade.Create(new CreateCommentCommand(userId, ProductId, Text));

        if (result.Status == OperationResultStatus.Error)
        {
            ModelState.AddModelError("Text", result.Message);
            return RedirectToPage("Product", new { slug });
        }

        return RedirectToPage("Product", new { slug });
    }

}