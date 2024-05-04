using Application.Users.Edit;
using Common.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PresentationFacade.Users;
using Query.Users.DTOs;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace WebApplication.Pages.UserPanel;
[Authorize]
public class EditModel : PageModel
{
    private readonly IUserFacade _userFacade;
    public EditModel(IUserFacade userFacade)
    {
        _userFacade = userFacade;
    }

    #region Properties
    public string UserId { get; set; }
    public UserDto UserDTO { get; set; }

    [Display(Name = "نام و نام خانوادگی")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    [BindProperty]
    public string FullName { get; set; }
    #endregion

    public void OnGet()
    {

    }

    public async Task<IActionResult> OnPost()
    {
        UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        long userId = Convert.ToInt64(UserId);
        UserDTO = await _userFacade.GetById(userId);
        if (UserDTO == null)
        {
            throw new Exception("کاربری وجود نداشت");
        }

        var result = _userFacade.Edit(new EditUserCommand(userId, FullName));

        if (result.Result.Status == OperationResultStatus.Error)
        {
            ModelState.AddModelError("UserName", result.Result.Message);
            return Page();
        }
        return Redirect("/UserPanel");
    }
}