using Common.Domain.ValueObjects;
using Common.Query.Bases;

namespace Query.Users.DTOs;
public class UserDto : BaseDto
{
    public string UserName { get; set; }
    public string FullName { get; set; }
    public PhoneNumber PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public UserRoleDto Roles { get; set; }
    public DateTime CreationDate { get; set; }
}

public enum UserRoleDto
{
    admin,
    user
}