using Common.Application;

namespace Application.Users.Edit;
public class EditUserCommand : IBaseCommand
{
    public EditUserCommand(long userId, string fullName)
    {
        UserId = userId;
        FullName = fullName;
    }

    public long UserId { get; set; }
    public string FullName { get; private set; }
}