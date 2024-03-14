using Common.Query.Bases;
using Domain.Users;

namespace Query.Users.DTO;
public class UserDTO : BaseDto
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string FullName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public UserRole Role { get; set; }
}