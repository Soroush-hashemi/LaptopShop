using Microsoft.AspNetCore.Mvc;
using Common.Application;
using Newtonsoft.Json;

namespace WebApplication.Areas.Admin;
[Area("Admin")]
// [Authorize(Policy = "AdminPolicy")]
public class AdminControllerBase : Controller
{
    protected IActionResult RedirectAndShowAlert(OperationResult result, IActionResult redirectPath)
    {
        var model = JsonConvert.SerializeObject(result);
        HttpContext.Response.Cookies.Append("SystemAlert", model);
        if (result.Status != OperationResultStatus.Success)
            return View();

        return redirectPath;
    }

    protected IActionResult RedirectAndShowAlert(Task<OperationResult<long>> result, IActionResult redirectPath)
    {
        var model = JsonConvert.SerializeObject(result);
        HttpContext.Response.Cookies.Append("SystemAlert", model);
        if (result.Equals(Ok()))
            return View();

        return redirectPath;
    }

    protected void SuccessAlert()
    {
        var model = JsonConvert.SerializeObject(OperationResult.Success());
        HttpContext.Response.Cookies.Append("SystemAlert", model);
    }

    protected void SuccessAlert(string message)
    {
        var model = JsonConvert.SerializeObject(OperationResult.Success(message));
        HttpContext.Response.Cookies.Append("SystemAlert", model);
    }

    protected void ErrorAlert()
    {
        var model = JsonConvert.SerializeObject(OperationResult.Error());
        HttpContext.Response.Cookies.Append("SystemAlert", model);
    }

    protected void ErrorAlert(string message)
    {
        var model = JsonConvert.SerializeObject(OperationResult.Error(message));
        HttpContext.Response.Cookies.Append("SystemAlert", model);
    }
}