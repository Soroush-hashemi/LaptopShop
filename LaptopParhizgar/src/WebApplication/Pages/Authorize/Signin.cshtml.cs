using Common.Application;
using Common.Application.SecurityUtil;
using Common.Application.Validation;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PresentationFacade.Users;
using Query.Users.DTOs;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace WebApplication.Pages.Authorize;

public class SigninModel : PageModel
{
    private readonly IUserFacade _userFacade;
    public SigninModel(IUserFacade userFacade)
    {
        _userFacade = userFacade;
    }

    #region Properties
    [BindProperty]
    [Display(Name = "نام کاربری")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    public string UserName { get; set; }

    [BindProperty]
    [Required(ErrorMessage = "کلمه عبور را وارد کنید")]
    public string Password { get; set; }
    #endregion

    public async Task<IActionResult> OnPost()
    {
        var user = await _userFacade.GetUserByUserName(UserName);
        if (user == null)
            ModelState.AddModelError("UserName", "کاربری با مشخصات وارد شده یافت نشد");

        var result = Signin(user);

        if (result.Result.Status == OperationResultStatus.Error)
        {
            ModelState.AddModelError("Password", result.Result.Message);
            return Page();
        }
        return RedirectToPage("../Index");
    }

    private async Task<OperationResult> Signin(UserDto user)
    {
        if (user == null)
        {
            var result = OperationResult.Error("کاربری با مشخصات وارد شده یافت نشد");
            return result;
        }

        var password = Sha256Hasher.Hash(Password);
        if (password != user.Password)
        {
            var result = OperationResult.Error("کاربری با مشخصات وارد شده یافت نشد");
            return result;
        }

        List<Claim> claims = new List<Claim>()
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.UserName.ToString()),
            new Claim(ClaimTypes.MobilePhone, user.PhoneNumber.Value.ToString()),
            new Claim(ClaimTypes.Role, user.Roles.ToString()),
        };

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var claimPrincipal = new ClaimsPrincipal(identity);
        var properties = new AuthenticationProperties()
        {
            IsPersistent = true
        };

        HttpContext.SignInAsync(claimPrincipal, properties);

        return OperationResult.Success();
    }
}