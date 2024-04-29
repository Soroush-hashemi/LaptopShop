using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using System.Net;

namespace WebApplication.Pages;

public class ErrorModel : PageModel
{
    public string Message { get; set; }
    public void OnGet(string message)
    {
        Message = WebUtility.UrlDecode(message);
    }
}