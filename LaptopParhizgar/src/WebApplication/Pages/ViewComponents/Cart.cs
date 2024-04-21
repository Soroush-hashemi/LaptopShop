using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PresentationFacade.Cart;
using Query.Cart.DTOs;
using System.Security.Claims;

namespace WebApplication.Pages.ViewComponents;

[Authorize]
public class Cart : ViewComponent
{
    private ICartFacade _cartFacade;
    public Cart(ICartFacade cartFacade)
    {
        _cartFacade = cartFacade;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        List<CartItemDto> cartItems = new List<CartItemDto>();

        string CurrentUserID = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        long UserId = Convert.ToInt32(CurrentUserID);
        cartItems = await _cartFacade.GetMyCart(UserId);

        return View(cartItems);
    }
}