using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Areas.Admin.Controllers;
public class HomeController : AdminControllerBase
{
    public IActionResult Index()
    {
        return View();
    }
}