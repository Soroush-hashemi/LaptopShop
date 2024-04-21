using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PresentationFacade.Cart;
using PresentationFacade.Cart.Service;
using Query.Cart.DTOs;
using System.Security.Claims;

namespace WebApplication.Pages.Cart;
[Authorize]
public class IndexModel : PageModel
{
    private readonly ICartFacade _cartFacade;
    private readonly ICartService _cartService;
    public IndexModel(ICartFacade cartFacade, ICartService cartService)
    {
        _cartFacade = cartFacade;
        _cartService = cartService;
    }

    #region Properties
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
    }

    public IActionResult Cart()
    {
        return Page();
    }
}