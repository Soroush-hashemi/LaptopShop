using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Areas.Admin.Controllers;
public class SliderPostersController : AdminControllerBase
{
    public IActionResult Index()
    {
        return View();
    }
}