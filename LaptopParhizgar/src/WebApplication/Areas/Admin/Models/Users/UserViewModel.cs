using Common.Domain.ValueObjects;
using Query.Users.DTOs;

namespace WebApplication.Areas.Admin.Models.Users;
public class UserViewModel
{
    public long Id { get; set; }
    public DateTime CreationDate { get; set; }
    public string UserName { get; set; }
    public string FullName { get; set; }
    public PhoneNumber PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public UserRoleDto Roles { get; set; }
}