using Common.Application;
using Common.Domain.ValueObjects;

namespace Application.Users.Register;
public class RegisterUserCommand : IBaseCommand
{
    public RegisterUserCommand(string userName, string fullName, string phoneNumber, string email, string password)
    {
        UserName = userName;
        FullName = fullName;
        PhoneNumber = new PhoneNumber(phoneNumber);
        Email = email;
        Password = password;
    }

    public string UserName { get; set; }
    public string FullName { get; set; }
    public PhoneNumber PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}