using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PresentationFacade.Cart;
using System.Security.Claims;

namespace WebApplication.Pages.Cart;
[Authorize]
public class AddToCartModel : PageModel
{
    private readonly ICartFacade _cartFacade;

    public AddToCartModel(ICartFacade cartFacade)
    {
        _cartFacade = cartFacade;
    }

    public async Task<IActionResult> OnGet(int ProductId)
    {
        if (ProductId == null && ProductId == 0)
        {
            return Redirect("Index");
        }

        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        int UserId = Convert.ToInt16(userId);
        var result = await _cartFacade.Add(ProductId, UserId);
        if (result.Status != Common.Application.OperationResultStatus.Success)
        {
            return Redirect("Index");
        }
        return Redirect("../Index");
    }
}