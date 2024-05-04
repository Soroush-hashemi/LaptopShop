using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication.Pages;
public class ServerErrorModel : PageModel
{
    public IActionResult OnGet()
    {
        return Page();
    }
}