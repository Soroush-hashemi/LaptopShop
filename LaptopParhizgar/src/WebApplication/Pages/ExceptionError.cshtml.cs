using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;

namespace WebApplication.Pages;
public class ExceptionErrorModel : PageModel
{
    public string Message { get; set; }
    public void OnGet(string message)
    {
        Message = WebUtility.UrlDecode(message);
    }
}