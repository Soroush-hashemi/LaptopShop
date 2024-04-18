using Common.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PresentationFacade.Users;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Pages.Authorize
{
    [ValidateAntiForgeryToken]
    public class CheckUserModel : PageModel
    {
        private readonly IUserFacade _userFacade;
        public CheckUserModel(IUserFacade userFacade)
        {
            _userFacade = userFacade;
        }

        #region Properties
        [BindProperty]
        [Required(ErrorMessage = "نام کاربری را وارد کنید")]
        public string UserName { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "شماره‌ موبایل را وارد کنید")]
        public string PhoneNumber { get; set; }
        #endregion

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            try
            {
                if (UserName == null)
                {
                    ModelState.AddModelError("UserName", "کاربری با مشخصات وارد شده یافت نشد");
                    ModelState.AddModelError("PhoneNumber", "کاربری با مشخصات وارد شده یافت نشد");
                    return Page();
                }

                var result = await _userFacade.CheckUser(UserName, PhoneNumber);
                if (result.Status == OperationResultStatus.Error)
                {
                    ModelState.AddModelError("UserName", result.Message);
                    ModelState.AddModelError("PhoneNumber", result.Message);
                    return Page();
                }

                return Redirect($"/Authorize/ChangePassword/{UserName}&{PhoneNumber}");

            }
            catch (NullReferenceException ex)
            {
                ModelState.AddModelError("UserName", ex.Message);
                ModelState.AddModelError("PhoneNumber", ex.Message);
                return Page();
            }
        }

    }
}
