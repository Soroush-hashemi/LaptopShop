using Application.Carts.RemoveItemFromCart;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PresentationFacade.Cart;

namespace WebApplication.Pages.Cart;

[Authorize]
public class RemoveFromCartModel : PageModel
{
    private readonly ICartFacade _cartFacade;
    public RemoveFromCartModel(ICartFacade cartFacade)
    {
        _cartFacade = cartFacade;
    }

    public async Task<IActionResult> OnGet(long Id)
    {
        await _cartFacade.RemoveItemFromCart(new RemoveItemFromCartCommand(Id));
        return Redirect("../Index");
    }
}