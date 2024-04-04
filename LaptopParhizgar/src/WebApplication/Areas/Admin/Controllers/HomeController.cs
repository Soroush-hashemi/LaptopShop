using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Areas.Admin.Controllers;
public class HomeController : AdminControllerBase
{
    [Route("/Admin")]
    public IActionResult Index()
    {
        return View();
    }
}