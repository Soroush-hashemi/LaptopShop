using Application.Carts.Decrease;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PresentationFacade.Cart;

namespace WebApplication.Pages.Cart;

[Authorize]
public class DecreaseModel : PageModel
{
    private readonly ICartFacade _cartFacade;
    public DecreaseModel(ICartFacade cartFacade)
    {
        _cartFacade = cartFacade;
    }

    public async Task<IActionResult> OnGet(long Id)
    {
        await _cartFacade.Decrease(new DecreaseProductCountCommand(Id));
        return Redirect("../Index");
    }
}