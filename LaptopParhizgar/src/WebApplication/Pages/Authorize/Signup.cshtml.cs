using Application.Users.Register;
using Common.Application;
using Common.Application.Validation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PresentationFacade.Users;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Pages.Authorize;
[BindProperties]
[ValidateAntiForgeryToken]
public class SignupModel : PageModel
{
    private readonly IUserFacade _userFacade;
    public SignupModel(IUserFacade userFacade)
    {
        _userFacade = userFacade;
    }

    #region Properties

    [Display(Name = "نام کاربری")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    public string UserName { get; set; }

    [Display(Name = "نام و نام خانوادگی")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    public string FullName { get; set; }

    [Display(Name = "کلمه عبور")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    [MinLength(6, ErrorMessage = "{0} باید بیشتر از 5 کاراکتر باشد")]
    public string Password { get; set; }

    [Display(Name = "ایمیل")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    public string Email { get; set; }

    [Display(Name = "شماره موبایل")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    [MaxLength(11, ErrorMessage = ValidationMessages.InvalidPhoneNumber)]
    [MinLength(11, ErrorMessage = ValidationMessages.InvalidPhoneNumber)]
    public string PhoneNumber { get; set; }
    #endregion

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPost()
    {
        if (ModelState.IsValid == false)
        {
            return Page();
        }

        var result = await _userFacade.Register(new RegisterUserCommand(UserName, FullName, PhoneNumber, Email, Password));
        if (result.Status == OperationResultStatus.Error)
        {
            ModelState.AddModelError("UserName", result.Message);
            return Page();
        }
        return RedirectToPage("Signin");
    }
}
