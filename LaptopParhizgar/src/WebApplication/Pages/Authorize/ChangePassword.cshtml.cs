using Common.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PresentationFacade.Users;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Pages.Authorize;
public class ChangePasswordModel : PageModel
{
    private readonly IUserFacade _userFacade;
    public ChangePasswordModel(IUserFacade userFacade)
    {
        _userFacade = userFacade;
    }

    #region Properties
    [BindProperty]
    public string userName { get; set; }
    [BindProperty]
    public string PhoneNumber { get; set; }

    [BindProperty]
    [Display(Name = "کلمه عبور")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    [MinLength(6, ErrorMessage = "{0} باید بیشتر از 5 کاراکتر باشد")]
    public string Password { get; set; }
    #endregion

    public void OnGet(string UserName, string phoneNumber)
    {
        userName = UserName;
        PhoneNumber = phoneNumber;
    }

    public async Task<IActionResult> OnPost()
    {
        var result = await _userFacade.ChangePassword(userName, PhoneNumber, Password);
        if (result.Status == OperationResultStatus.Error)
        {
            ModelState.AddModelError("Password", result.Message);
            return Page();
        }
        return RedirectToPage("Signin");
    }
}