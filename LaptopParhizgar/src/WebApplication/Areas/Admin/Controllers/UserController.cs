using Microsoft.AspNetCore.Mvc;
using PresentationFacade.Users;
using WebApplication.Areas.Admin.Models.Categories;
using WebApplication.Areas.Admin.Models.Users;

namespace WebApplication.Areas.Admin.Controllers;
public class UserController : AdminControllerBase
{
    private readonly IUserFacade _userFacade;
    public UserController(IUserFacade userFacade)
    {
        _userFacade = userFacade;
    }

    public async Task<IActionResult> Index()
    {
        var user = await _userFacade.GetList();

        return View(user.MapList());
    }

    [Route("/Admin/User/Delete/{UserId}")]
    public IActionResult Delete(long UserId)
    {
        var UserCommand = UserId;
        var result = _userFacade.Delete(UserCommand);

        if (result.Result.Status != Common.Application.OperationResultStatus.Success)
        {
            ErrorAlert($"{result.Result.Message}");
            return RedirectToAction();
        }

        SuccessAlert();
        return RedirectToAction("Index");
    }
}