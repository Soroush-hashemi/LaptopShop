using System.Security.Claims;

namespace WebApplication.Pages.Shared.Tool;
public static class UserUtil
{
    public static long GetUserId(this ClaimsPrincipal principal)
    {
        if (principal == null)
            throw new ArgumentNullException(nameof(principal));

        return Convert.ToInt32(principal.FindFirst(ClaimTypes.NameIdentifier)?.Value);
    }
}
