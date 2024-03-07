using Common.Domain.Bases;

namespace Common.Domain.Exceptions;
public class UserNotFoundException : BaseDomainException
{
    public UserNotFoundException()
    {

    }

    public static void Check()
    {
        throw new NotImplementedException("کاربر وجود ندارد");
    }
}