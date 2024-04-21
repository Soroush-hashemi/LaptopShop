using Application.Carts.Increase;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PresentationFacade.Cart;

namespace WebApplication.Pages.Cart;

[Authorize]
public class IncreaseModel : PageModel
{
    private readonly ICartFacade _cartFacade;
    public IncreaseModel(ICartFacade cartFacade)
    {
        _cartFacade = cartFacade;
    }

    public async Task<IActionResult> OnGet(long Id)
    {
        await _cartFacade.Increase(new IncreaseProductCountCommand(Id));
        return Redirect("../Index");
    }
}