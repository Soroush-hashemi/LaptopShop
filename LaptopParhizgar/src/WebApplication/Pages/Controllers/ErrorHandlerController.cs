using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Pages.Controllers;
public class ErrorHandlerController : Controller
{
    [Route("/ErrorHandler/{code}")]
    public IActionResult Index(int code)
    {
        switch (code)
        {
            case 404:
                return View("../Views/NotFound");
            case 500:
                return View("../Views/ServerError");
            case 401:
                return View("../Views/Unauthorized");
        }
        return View("NotFound");
    }
}