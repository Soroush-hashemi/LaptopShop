using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PresentationFacade.Users;
using Query.Users.DTOs;
using System.Security.Claims;

namespace WebApplication.Pages.UserPanel;
[Authorize]
public class IndexModel : PageModel
{
    private readonly IUserFacade _userFacade;
    public IndexModel(IUserFacade userFacade)
    {
        _userFacade = userFacade;
    }

    #region Properties
    public string UserId { get; set; }
    public UserDto? UserDTO { get; set; }
    #endregion

    public async void OnGet()
    {
        UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        long userId = Convert.ToInt64(UserId);
        UserDTO = await _userFacade.GetById(userId);
    }
}