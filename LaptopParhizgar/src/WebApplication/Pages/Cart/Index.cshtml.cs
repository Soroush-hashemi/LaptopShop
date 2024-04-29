using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PresentationFacade.Cart;
using PresentationFacade.Cart.Service;
using PresentationFacade.Categories;
using Query.Cart.DTOs;
using Query.Categories.DTOs;
using System.Security.Claims;

namespace WebApplication.Pages.Cart;
[Authorize]
public class IndexModel : PageModel
{
    private readonly ICartFacade _cartFacade;
    private readonly ICartService _cartService;
    private readonly ICategoryFacade _categoryFacade;
    public IndexModel(ICartFacade cartFacade, ICartService cartService , ICategoryFacade categoryFacade)
    {
        _cartFacade = cartFacade;
        _cartService = cartService;
        _categoryFacade = categoryFacade;
    }

    #region Properties
    public List<CategoryDto> Categories { get; set; }

    [BindProperty]
    public List<CartItemDto> CartItem { get; set; }
    public long TotalPrice { get; set; }
    #endregion

    public async void OnGet()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        long UserId = Convert.ToInt16(userId);
        CartItem = await _cartFacade.GetMyCart(UserId);  
        TotalPrice = await _cartService.GetTotalPrice(UserId);
        Categories = await _categoryFacade.GetList();
    }

    public IActionResult Cart()
    {
        return Page();
    }
}