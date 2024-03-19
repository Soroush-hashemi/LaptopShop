using Query.Users.DTOs;
using Common.Query;

namespace Query.Users.GetById;
public class GetUserByIdQuery : IQuery<UserDto>
{
    public long UserId { get; private set; }
    public GetUserByIdQuery(long userId)
    {
        UserId = userId;
    }
}