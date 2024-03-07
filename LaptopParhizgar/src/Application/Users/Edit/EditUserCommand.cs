using Common.Application;
using Common.Domain.ValueObjects;

namespace Application.Users.Edit;
public class EditUserCommand : IBaseCommand
{
    public EditUserCommand(long userId, string userName, string fullName, PhoneNumber phoneNumber, string email)
    {
        UserId = userId;
        UserName = userName;
        FullName = fullName;
        PhoneNumber = phoneNumber;
        Email = email;
    }

    public long UserId { get; set; }
    public string UserName { get; private set; }
    public string FullName { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; }
    public string Email { get; private set; }
}